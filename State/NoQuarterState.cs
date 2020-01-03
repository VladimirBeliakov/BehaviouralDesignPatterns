using System;

namespace State
{
	internal class NoQuarterState : IState
	{
		private readonly GumBallMachine _gumBallMachine;

		public NoQuarterState(GumBallMachine gumBallMachine)
		{
			_gumBallMachine = gumBallMachine;
		}

		public void InsertQuarter()
		{
			_gumBallMachine.SetState(_gumBallMachine.HasQuarterState);
			Console.WriteLine("You inserted a quarter.");
		}

		public bool TryTurnCrank()
		{
			Console.WriteLine("Insert a quarter first.");

			return false;
		}

		public void EjectQuarter()
		{
			Console.WriteLine("There's no quarters in the machine.");
		}

		public void Dispense()
		{
			Console.WriteLine("To get a gum ball insert a quarter and turn the crank.");
		}
	}
}