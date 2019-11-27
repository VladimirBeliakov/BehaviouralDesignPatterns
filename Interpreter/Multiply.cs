namespace Interpreter
{
	public class Multiply : IRpnExpression
	{
		private readonly IRpnExpression _leftExpression;
		private readonly IRpnExpression _rightExpression;

		public Multiply(IRpnExpression leftExpression, IRpnExpression rightExpression)
		{
			_leftExpression = leftExpression;
			_rightExpression = rightExpression;
		}
		
		public int Interpret()
		{
			return _leftExpression.Interpret() * _rightExpression.Interpret();
		}
	}
}