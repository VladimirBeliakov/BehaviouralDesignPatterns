namespace State.CourseVersion
{
	public abstract class State
	{
		public abstract void InsertCoin(VendingMachine context);
		public abstract void EjectCoin(VendingMachine context);
		public abstract void PushButton(VendingMachine context);
		public abstract void DispenseChocolate(VendingMachine context);
	}
}