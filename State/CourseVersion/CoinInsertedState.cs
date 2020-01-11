using System;

namespace State.CourseVersion
{
	public class CoinInsertedState : State
	{
		public override void InsertCoin(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't insert coin when another one was already inserted.");
		}

		public override void EjectCoin(VendingMachine context)
		{
			context.State = new NoCoinState();
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine("Coin ejected.");
		}

		public override void PushButton(VendingMachine context)
		{
			context.State = new SoldState();
		}

		public override void DispenseChocolate(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't dispense chocolate. The button wasn't pressed.");
		}
	}
}