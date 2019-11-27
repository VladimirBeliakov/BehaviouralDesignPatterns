using System;

namespace ChainOfResponsibility
{
	public class LowSecurityLevelHandler : IHandler
	{
		public IHandler Successor { get; }

		public LowSecurityLevelHandler(IHandler successor)
		{
			Successor = successor;
		}
		
		public void HandleRequest(SecurityLevel securityLevel)
		{
			if (securityLevel == SecurityLevel.Low)
				Console.WriteLine("Approved (low level)");
			else if (Successor != null)
				Successor.HandleRequest(securityLevel);
			else
				throw new UnauthorizedAccessException();
		}
	}
}