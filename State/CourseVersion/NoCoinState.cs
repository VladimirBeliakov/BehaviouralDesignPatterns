using System;

namespace State.CourseVersion
{
	public class NoCoinState : State
	{
		public override void InsertCoin(VendingMachine context)
		{
			if (context.Products > 0)
			{
				context.State = new CoinInsertedState();
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Coin inserted.");
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Sold out.");
			}
		}

		public override void EjectCoin(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't eject coin when no coin was inserted before.");
		}

		public override void PushButton(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("No coin was inserted.");
		}

		public override void DispenseChocolate(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't dispense chocolate. No coin was inserted.");
		}
	}
}