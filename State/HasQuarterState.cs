using System;

namespace State
{
	internal class HasQuarterState : IState
	{
		private readonly GumBallMachine _gumBallMachine;

		public HasQuarterState(GumBallMachine gumBallMachine)
		{
			_gumBallMachine = gumBallMachine;
		}
		public void InsertQuarter()
		{
			Console.WriteLine("You already inserted a quarter.");
		}

		public bool TryTurnCrank()
		{
			_gumBallMachine.SetState(_gumBallMachine.SoldState);
			Console.WriteLine("A gum ball is going to be given to you.");

			return true;
		}

		public void EjectQuarter()
		{
			_gumBallMachine.SetState(_gumBallMachine.NoQuarterState);
			Console.WriteLine("You can take your quarter back.");
		}

		public void Dispense()
		{
			Console.WriteLine("Turn the crank to get your gum ball.");
		}
	}
}