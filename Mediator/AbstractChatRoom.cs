using System.Collections.Generic;

namespace Mediator
{
	public abstract class AbstractChatRoom
	{
		protected HashSet<AbstractVisitor> _activeVisitors = new HashSet<AbstractVisitor>();

		public abstract void Send(string message, AbstractVisitor sender);

		public abstract void Unregistered(AbstractVisitor abstractVisitor);

		public abstract void Register(AbstractVisitor abstractVisitor);
	}
}