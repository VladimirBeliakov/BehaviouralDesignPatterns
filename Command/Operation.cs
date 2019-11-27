using System;

namespace Command
{
	public class Operation : IOperation
	{
		private readonly MathReceiver _receiver;
		private readonly MathOperation _operation;
		private readonly int _value;

		public Operation(MathReceiver receiver, MathOperation operation, int value)
		{
			_receiver = receiver;
			_operation = operation;
			_value = value;
		}
		
		public void Execute()
		{
			switch(_operation)
			{
				case MathOperation.Addition:
					_receiver.Add(_value);
					break;
				case MathOperation.Subtraction:
					_receiver.Subtract(_value);
					break;
				case MathOperation.Multiplication:
					_receiver.Multiply(_value);
					break;
				case MathOperation.Division:
					_receiver.Divide(_value);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}