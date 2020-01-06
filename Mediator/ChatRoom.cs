namespace Mediator
{
	public class ChatRoom : AbstractChatRoom
	{
		public override void Unregistered(AbstractVisitor abstractVisitor)
		{
			_activeVisitors.Remove(abstractVisitor);
		}

		public override void Register(AbstractVisitor abstractVisitor)
		{
			_activeVisitors.Add(abstractVisitor);
		}

		public override void Send(string message, AbstractVisitor sender)
		{
			foreach (var visitor in _activeVisitors)
			{
				if (visitor != sender)
					visitor.Receive(message);
			}
		}
	}
}