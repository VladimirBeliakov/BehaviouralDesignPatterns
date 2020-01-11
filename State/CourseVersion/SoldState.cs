using System;

namespace State.CourseVersion
{
	public class SoldState : State
	{
		public override void InsertCoin(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't insert coin when chocolate hasn't been dispense after pushing the button.");
		}

		public override void EjectCoin(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Can't eject the coin because the button has already been pushed.");
		}

		public override void PushButton(VendingMachine context)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("The button already been pushed. Dispensing a chocolate bar.");
		}

		public override void DispenseChocolate(VendingMachine context)
		{
			context.Products--;

			if (context.Products > 0)
				context.State = new NoCoinState();
			else
				context.State = new SoldOutState();
			
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Chocolate bar dispensed.");
		}
	}
}