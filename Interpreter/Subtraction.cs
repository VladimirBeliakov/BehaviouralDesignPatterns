namespace Interpreter
{
	public class Subtraction : IRpnExpression
	{
		private readonly IRpnExpression _leftExpression;
		private readonly IRpnExpression _rightExpression;

		public Subtraction(IRpnExpression leftExpression, IRpnExpression rightExpression)
		{
			_leftExpression = leftExpression;
			_rightExpression = rightExpression;
		}
		
		public int Interpret()
		{
			return _leftExpression.Interpret() - _rightExpression.Interpret();
		}
	}
}