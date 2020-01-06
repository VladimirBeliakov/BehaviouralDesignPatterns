using System;

namespace Mediator
{
	public class Visitor : AbstractVisitor
	{
		public Visitor(string name)
		{
			_name = name;
		}
		
		public override void Receive(string message)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"{_name} <-- {message}");
		}
	}
}