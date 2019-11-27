namespace Command
{
	public class CalculatorInvoker
	{
		public CalculatorInvoker()
		{
		}

		public void Invoke(IOperation operation)
		{
			operation.Execute();
		}
	}
}