using System;

namespace ChainOfResponsibility
{
	public class HighSecurityLevelHandler : IHandler
	{
		public IHandler Successor { get; }

		public HighSecurityLevelHandler(IHandler successor)
		{
			Successor = successor;
		}
		
		public void HandleRequest(SecurityLevel securityLevel)
		{
			if (securityLevel == SecurityLevel.Low ||
				securityLevel == SecurityLevel.Medium ||
				securityLevel == SecurityLevel.High)
				Console.WriteLine("Approved (high level)");
			else
				throw new UnauthorizedAccessException();
		}
	}
}