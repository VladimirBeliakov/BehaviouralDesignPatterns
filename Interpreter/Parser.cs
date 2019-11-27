using System.Collections.Generic;

namespace Interpreter
{
	public class Parser
	{
		public IRpnExpression Parse(string value)
		{
			var words = value.Split(' ');
			
			var stack = new Stack<IRpnExpression>(words.Length);

			foreach (var word in words)
			{
				IRpnExpression leftExpression;
				IRpnExpression rightExpression;
				switch (word)
				{
					case "+":
						leftExpression = stack.Pop();
						rightExpression = stack.Pop();
						stack.Push(new Add(leftExpression, rightExpression));
						continue;
					case "-":
						leftExpression = stack.Pop();
						rightExpression = stack.Pop();
						stack.Push(new Subtraction(leftExpression, rightExpression));
						continue;
					case "*":
						leftExpression = stack.Pop();
						rightExpression = stack.Pop();
						stack.Push(new Multiply(leftExpression, rightExpression));
						continue;
					case "/":
						leftExpression = stack.Pop();
						rightExpression = stack.Pop();
						stack.Push(new Divide(leftExpression, rightExpression));
						continue;
					default:
						stack.Push(new Number(int.Parse(word)));
						continue;
				}
			}

			return stack.Pop();
		}
	}
}