using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Threading;
using Composite;
using Factory.IngredientFactory;
using Factory.PizzaFactories;
using Factory.Pizzas;
using Factory.Stores;
using Iterator;

namespace Program
{
	internal static class Program
	{
		public static void Main(string[] args)
		{
//			runIterator();
//			runFactory();
//			Marshalling();
//			FieldAccessTiming();
//			runComposite();
			runState();
		}

		private static void runIterator()
		{
			var stringCollection =
				new StringCollection("item one", "item two", "item three");

			foreach (var item in stringCollection)
				Console.WriteLine(item);
		}

		private static void runFactory()
		{
			var pizzaStore = new PizzaStore(new PizzaFactory(new SyracuseIngredientFactory()));

			var pizza = pizzaStore.OrderPizza(PizzaStyle.Pepperoni);
		}

		private static void Marshalling()
		{
// Get a reference to the AppDomain that the calling thread is executing in
			AppDomain adCallingThreadDomain = Thread.GetDomain();
// Every AppDomain is assigned a friendly string name (helpful for debugging)
// Get this AppDomain’s friendly string name and display it
			String callingDomainName = adCallingThreadDomain.FriendlyName;
			Console.WriteLine("Default AppDomain’s friendly name={0}", callingDomainName);
// Get and display the assembly in our AppDomain that contains the ‘Main’ method
			String exeAssembly = Assembly.GetEntryAssembly().FullName;
			Console.WriteLine("Main assembly={0}", exeAssembly);
// Define a local variable that can refer to an AppDomain
			AppDomain ad2 = null;
// *** DEMO 1: Cross-AppDomain Communication using Marshal-by-Reference ***
			Console.WriteLine("{0}Demo #1", Environment.NewLine);
// Create new AppDomain (security and configuration match current AppDomain)
			ad2 = AppDomain.CreateDomain("AD #2", null, null);
			MarshalByRefType mbrt = null;
			// Load our assembly into the new AppDomain, construct an object, marshal
			// it back to our AD (we really get a reference to a proxy)

			var executingAssembly = Assembly.GetEntryAssembly();

			mbrt = (MarshalByRefType)
				ad2.CreateInstanceAndUnwrap(exeAssembly, "Program.MarshalByRefType");
			Console.WriteLine("Type={0}", mbrt.GetType()); // The CLR lies about the type
// Prove that we got a reference to a proxy object
			Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));
// This looks like we’re calling a method on MarshalByRefType but, we’re not.
// We’re calling a method on the proxy type. The proxy transitions the thread
// to the AppDomain owning the object and calls this method on the real object.
			mbrt.SomeMethod();
// Unload the new AppDomain
			AppDomain.Unload(ad2);
// mbrt refers to a valid proxy object; the proxy object refers to an invalid AppDomain
			try
			{
// We’re calling a method on the proxy type. The AD is invalid, exception is thrown
				mbrt.SomeMethod();
				Console.WriteLine("Successful call.");
			}
			catch (AppDomainUnloadedException)
			{
				Console.WriteLine("Failed call.");
			}

			// *** DEMO 2: Cross-AppDomain Communication using Marshal-by-Value ***
			Console.WriteLine("{0}Demo #2", Environment.NewLine);
			// Create new AppDomain (security and configuration match current AppDomain)

			var evidence = new Evidence();

			var appDomainSetup = new AppDomainSetup();

			ad2 = AppDomain.CreateDomain("AD #2", null, null);
			// Load our assembly into the new AppDomain, construct an object, marshal
			// it back to our AD (we really get a reference to a proxy)
			mbrt = (MarshalByRefType)
				ad2.CreateInstanceAndUnwrap(exeAssembly, "Program.MarshalByRefType");
			// The object’s method returns a COPY of the returned object;
			// the object is marshaled by value (not be reference).
			MarshalByValType mbvt = mbrt.MethodWithReturn();
// Prove that we did NOT get a reference to a proxy object
			Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbvt));
// This looks like we’re calling a method on MarshalByValType and we are.
			Console.WriteLine("Returned object created " + mbvt.ToString());
// Unload the new AppDomain
			AppDomain.Unload(ad2);
// mbvt refers to valid object; unloading the AppDomain has no impact.
			try
			{
				Console.WriteLine("running in {0}", Thread.GetDomain().FriendlyName);
// We’re calling a method on an object; no exception is thrown
				Console.WriteLine("Returned object created " + mbvt.ToString());
				Console.WriteLine("Successful call.");
			}
			catch (AppDomainUnloadedException)
			{
				Console.WriteLine("Failed call.");
			}

// DEMO 3: Cross-AppDomain Communication using non-marshalable type ***
			Console.WriteLine("{0}Demo #3", Environment.NewLine);
// Create new AppDomain (security and configuration match current AppDomain)
			ad2 = AppDomain.CreateDomain("AD #2", null, null);
// Load our assembly into the new AppDomain, construct an object, marshal
// it back to our AD (we really get a reference to a proxy)
			mbrt = (MarshalByRefType)
				ad2.CreateInstanceAndUnwrap(exeAssembly, "Program.MarshalByRefType");
// The object’s method returns a non-marshalable object; exception
			NonMarshalableType nmt = mbrt.MethodArgAndReturn(callingDomainName);
// We won’t get here...
		}

		private sealed class NonMBRO : Object
		{
			public Int32 x;
		}

		private sealed class MBRO : MarshalByRefObject
		{
			public static Int32 x;
		}

		private static void FieldAccessTiming()
		{
			const Int32 count = 100000000;
			NonMBRO nonMbro = new NonMBRO();
			MBRO mbro = new MBRO();
			Stopwatch sw = Stopwatch.StartNew();
			for (Int32 c = 0; c < count; c++) nonMbro.x++;
			Console.WriteLine("{0}", sw.Elapsed); // 00:00:00.4073560
			sw = Stopwatch.StartNew();
			for (Int32 c = 0; c < count; c++) MBRO.x++;
			Console.WriteLine("{0}", sw.Elapsed); // 00:00:02.5388665
		}

		private static void runComposite()
		{
			var rootMenu = new Menu("Breakfast", "Pancakes, Eggs, Bacon");

			var rootMenuItem = new MenuItem("Sweet hot tea", "Tea", 5, true);

			var rootMenuLevelOne = new Menu("Dessert", "Sweets and Candy");

			var menuItemLevelOne = new MenuItem("Chocolate candy bar", "Candy", 2, true);

			rootMenuLevelOne.Add(menuItemLevelOne);

			rootMenu.Add(rootMenuLevelOne);
			rootMenu.Add(rootMenuItem);

			foreach (var menu in rootMenu)
			{
				try
				{
					if (menu.IsVegetarian())
						menu.Print();
				}
				catch (NotImplementedException)
				{
				}
			}
		}

		private static void runState()
		{
			var number1 = 10;

			Console.WriteLine($"{number1++ == 10}");

			var number2 = 10;

			Console.WriteLine($"{++number2 == 10}");
		}
	}
}