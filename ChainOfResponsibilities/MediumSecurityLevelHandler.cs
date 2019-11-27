using System;

namespace ChainOfResponsibility
{
	public class MediumSecurityLevelHandler : IHandler
	{
		public IHandler Successor { get; }

		public MediumSecurityLevelHandler(IHandler successor)
		{
			Successor = successor;
		}

		public void HandleRequest(SecurityLevel securityLevel)
		{
			if (securityLevel == SecurityLevel.Low || securityLevel == SecurityLevel.Medium)
				Console.WriteLine("Approved (medium level)");
			else if (Successor != null)
				Successor.HandleRequest(securityLevel);
			else
				throw new UnauthorizedAccessException();
		}
	}
}