using System;
using System.Threading;

namespace Program
{
	// Instances cannot be marshaled across AppDomain boundaries
	[Serializable]
	public class NonMarshalableType : Object
	{
		public NonMarshalableType()
		{
			Console.WriteLine("Executing in " + Thread.GetDomain().FriendlyName);
		}
	}

	[Serializable]
	public class NonMarshalableTypeImpl : NonMarshalableType
	{
	}
}