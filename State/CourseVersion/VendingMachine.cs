namespace State.CourseVersion
{
	public class VendingMachine
	{
		public int Products { get; set; } = 10;
		public State State { get; set; } = new NoCoinState();
		
		public void InsertCoin()
		{
			State.InsertCoin(this);
		}

		public void EjectCoin()
		{
			State.EjectCoin(this);
		}

		public void PushButton()
		{
			State.PushButton(this);
			State.DispenseChocolate(this);
		}
	}
}