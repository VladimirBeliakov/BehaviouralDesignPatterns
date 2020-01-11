using System;

namespace State.BookVersion
{
	public class GumBallMachine
	{
		private IState _state;
		private readonly Random _rnd = new Random();

		public GumBallMachine(int gumBallCount)
		{
			if (gumBallCount < 0)
				throw new InvalidOperationException($"{nameof(gumBallCount)} can't be negative.");

			NoQuarterState = new NoQuarterState(this);
			HasQuarterState = new HasQuarterState(this);
			SoldState = new SoldState(this);
			SoldOutState = new SoldOutState();
			_winnerState = new WinnerState(this);

			GumBallCount = gumBallCount;
			_state = NoQuarterState;
		}

		public void InsertQuarter()
		{
			_state.InsertQuarter();
		}

		public void TurnCrank()
		{
			if (_state.TryTurnCrank())
			{
				_state.Dispense();

				if (GumBallCount > 0 && _rnd.Next(0, 10) == 0)
					_winnerState.Dispense();
			}
		}

		public void EjectQuarter()
		{
			_state.EjectQuarter();
		}

		internal void ReleaseGumBall()
		{
			if (GumBallCount > 0)
				GumBallCount--;
			else
				throw new InvalidOperationException("Can't release a gum ball. The machine is empty.");
		}
		
		internal void SetState(IState newState)
		{
			if (_state == newState)
				throw new InvalidOperationException(
					$"The current state is already {newState.GetType()}. " +
					$"It's only possible to change the state to a different one."
				);

			_state = newState;
		}

		internal IState SoldState { get; }

		internal IState SoldOutState { get; }

		internal IState HasQuarterState { get; }

		internal IState NoQuarterState { get; }

		public int GumBallCount { get; private set; }

		private readonly WinnerState _winnerState;
	}
}