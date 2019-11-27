namespace Interpreter
{
	public class Number : IRpnExpression
	{
		private readonly int _value;

		public Number(int value)
		{
			_value = value;
		}
		
		public int Interpret()
		{
			return _value;
		}
	}
}