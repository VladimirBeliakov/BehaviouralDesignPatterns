using System;
using System.Runtime.InteropServices;

namespace Mediator
{
	public abstract class AbstractVisitor
	{
		protected AbstractChatRoom _currentChatRoom;

		protected string _name;

		public void Send(string message)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine($"{_name} --> {message}");
			_currentChatRoom.Send(message, this);
		}

		public abstract void Receive(string message);

		public void Enter(AbstractChatRoom chatRoom)
		{
			if (_currentChatRoom != null)
			{
				Leave();
			}

			chatRoom.Register(this);
			_currentChatRoom = chatRoom;
		}

		public void Leave()
		{
			if (_currentChatRoom != null)
			{
				_currentChatRoom.Unregistered(this);
				_currentChatRoom = null;
			}
		}
	}
}