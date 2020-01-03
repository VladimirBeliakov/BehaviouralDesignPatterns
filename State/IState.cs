namespace State
{
	public interface IState
	{
		void InsertQuarter();

		bool TryTurnCrank();

		void EjectQuarter();

		void Dispense();
	}
}