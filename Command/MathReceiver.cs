using System;

namespace Command
{
	public class MathReceiver
	{
		public int Value { get; private set; }

		public void Add(int value)
		{
			if (value < 0)
				throw new InvalidOperationException();
			
			Value += value;
		}

		public void Subtract(int value)
		{
			if (value < 0)
				throw new InvalidOperationException();
			
			Value -= value;
		}
		
		public void Multiply(int value)
		{
			if (value < 0)
				throw new InvalidOperationException();
			
			Value *= value;
		}
		
		public void Divide(int value)
		{
			if (value < 0)
				throw new InvalidOperationException();
			
			Value /= value;
		}
	}
}