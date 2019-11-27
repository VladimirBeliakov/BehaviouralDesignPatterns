namespace ChainOfResponsibility
{
	public interface IHandler
	{
		IHandler Successor { get; }

		void HandleRequest(SecurityLevel securityLevel);
	}
}