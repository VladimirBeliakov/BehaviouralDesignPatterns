using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Composite;
using Factory.IngredientFactory;
using Factory.PizzaFactories;
using Factory.Pizzas;
using Factory.Stores;
using Iterator;
using Mediator;
using Memento;
using Observer;
using State.CourseVersion;
using Timer = Observer.Timer;

namespace Program
{
	internal static class Program
	{
		public static async Task Main(string[] args)
		{
//			runIterator();
//			runFactory();
//			Marshalling();
//			FieldAccessTiming();
//			runComposite();
//			runState();
//			runMediator();
//			runMemento();
//			await runObserver();
			runCourseVersionState();
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
				catch (NotImplementedException) { }
			}
		}

		private static void recursivelyIterateOverMenu(IMenuComponent menu)
		{
			foreach (var menuItem in menu)
			{
				
			}
		}

		private static void runMediator()
		{
			var chatRoom = new ChatRoom();

			var visitor1 = new Visitor("Bob");
			var visitor2 = new Visitor("Jack");
			var visitor3 = new Visitor("John");
			
			visitor1.Enter(chatRoom);
			visitor2.Enter(chatRoom);
			visitor3.Enter(chatRoom);

			visitor1.Send("Hi there");

			visitor2.Send("Hi, my name is Jack");

			visitor3.Send("Hey, what's up?");
		}

		private static void runState()
		{
			var number1 = 10;

			Console.WriteLine($"{number1++ == 10}");

			var number2 = 10;

			Console.WriteLine($"{++number2 == 10}");
		}

		private static void runMemento()
		{
			var document = new Document();
			var history = new DocumentHistory(document);
			
			document.Append("First revision");
			history.SnapShot();
			document.Bold();
			history.SnapShot();
			document.Italic();
			history.SnapShot();

			Console.WriteLine("Before restoring history.");
			Console.WriteLine(document.ToString());
			
			history.Restore(1);
			Console.WriteLine("Revision 2 restored.");
			Console.WriteLine(document.ToString());

			history.Restore(0);
			Console.WriteLine("Revision 1 restored.");
			Console.WriteLine(document.ToString());
		}

		private static async Task runObserver()
		{
			var timer = new Timer();
			var clock = new ConsoleClock();

			timer.Notify += clock.Update;

			timer.Start();

			await Task.Delay(4000);

			timer.Notify -= clock.Update;

			await Task.Delay(2000);

			timer.Notify += clock.Update;
		}

		private static void runCourseVersionState()
		{
			var vendorMachine = new VendingMachine();

			Console.WriteLine("Insert a coin: 1");
			Console.WriteLine("Eject a coin: 2");
			Console.WriteLine("Push the button: 3");

			while (true)
			{

				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Enter an action code");
				
				var action = Console.ReadLine();

				switch (action)
				{
					case "1":
						vendorMachine.InsertCoin();
						break;
					case "2":
						vendorMachine.EjectCoin();
						break;
					case "3":
						vendorMachine.PushButton();
						break;
					default:
						Console.WriteLine("Wrong action code.");
						break;
				}
			}
		}
	}
}