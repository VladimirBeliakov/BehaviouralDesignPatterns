using System;

namespace State.CourseVersion
{
	public class SoldOutState : State
	{
		public override void InsertCoin(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("The coin can't be inserted. Sold out.");
		}

		public override void EjectCoin(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't eject the coin. Sold out.");
		}

		public override void PushButton(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("The button can't be pushed. Sold out.");
		}

		public override void DispenseChocolate(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't dispense chocolate. Sold out.");
		}
	}
}