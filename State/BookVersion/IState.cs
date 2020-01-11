namespace State.BookVersion
{
	public interface IState
	{
		void InsertQuarter();

		bool TryTurnCrank();

		void EjectQuarter();

		void Dispense();
	}
}