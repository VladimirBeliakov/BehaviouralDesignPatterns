namespace Interpreter
{
	public class Divide : IRpnExpression
	{
		private readonly IRpnExpression _leftExpression;
		private readonly IRpnExpression _rightExpression;

		public Divide(IRpnExpression leftExpression, IRpnExpression rightExpression)
		{
			_leftExpression = leftExpression;
			_rightExpression = rightExpression;
		}
		
		public int Interpret()
		{
			return _leftExpression.Interpret() / _rightExpression.Interpret();
		}
	}
}