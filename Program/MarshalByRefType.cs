using System;
using System.Threading;

namespace Program
{
	// Instances can be marshaled-by-reference across AppDomain boundaries
	public sealed class MarshalByRefType : MarshalByRefObject
	{
		public MarshalByRefType()
		{
			Console.WriteLine("{0} ctor running in {1}",
				this.GetType().ToString(), Thread.GetDomain().FriendlyName);
		}

		public void SomeMethod()
		{
			Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
		}

		public MarshalByValType MethodWithReturn()
		{
			Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
			MarshalByValType t = new MarshalByValType();
			return t;
		}

		public NonMarshalableTypeImpl MethodArgAndReturn(String callingDomainName)
		{
			// NOTE: callingDomainName is [Serializable]
			Console.WriteLine("Calling from ‘{0}’ to ‘{1}’.",
				callingDomainName, Thread.GetDomain().FriendlyName);
			NonMarshalableTypeImpl t = new NonMarshalableTypeImpl();
			return t;
		}
	}
}