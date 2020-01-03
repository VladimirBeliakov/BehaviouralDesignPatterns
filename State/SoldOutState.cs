using System;

namespace State
{
	internal class SoldOutState : IState
	{
		public void InsertQuarter()
		{
			Console.WriteLine("The machine is sold out. You can't insert a quarter.");
		}

		public bool TryTurnCrank()
		{
			Console.WriteLine("The machine is sold out and has no gum balls.");

			return false;
		}

		public void EjectQuarter()
		{
			Console.WriteLine("The machine is sold out and has no quarters injected.");
		}

		public void Dispense()
		{
			Console.WriteLine("The machine is fresh out of gum balls.");
		}
	}
}