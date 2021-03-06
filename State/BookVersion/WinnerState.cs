﻿using System;

namespace State.BookVersion
{
	internal class WinnerState : IState
	{
		private readonly GumBallMachine _gumBallMachine;

		public WinnerState(GumBallMachine gumBallMachine)
		{
			_gumBallMachine = gumBallMachine;
		}

		public void InsertQuarter()
		{
			Console.WriteLine(
				"The gum ball is being given to you. Wait for that to finish before inserting another quarter."
			);
		}

		public bool TryTurnCrank()
		{
			Console.WriteLine("The gum ball was just given to you. Insert a quarter to get another gum ball.");

			return false;
		}

		public void EjectQuarter()
		{
			Console.WriteLine("The gum ball was just given to you. The quarter can't be retrieved.");
		}

		public void Dispense()
		{
			Console.WriteLine("Jackpot! You get an extra gum ball.");
			_gumBallMachine.ReleaseGumBall();

			if (_gumBallMachine.GumBallCount > 0)
				_gumBallMachine.SetState(_gumBallMachine.NoQuarterState);
			else
			{
				_gumBallMachine.SetState(_gumBallMachine.SoldOutState);
				Console.WriteLine("The machine is out of gum balls.");
			}
		}
	}
}