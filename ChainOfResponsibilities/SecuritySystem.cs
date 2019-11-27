namespace ChainOfResponsibility
{
	public class SecuritySystem
	{
		private IHandler firstHandler;
		
		public SecuritySystem()
		{
			firstHandler =
				new LowSecurityLevelHandler(
					new MediumSecurityLevelHandler(
						new HighSecurityLevelHandler(null)));
		}

		public void HandlerRequest(SecurityLevel securityLevel)
		{
			firstHandler.HandleRequest(securityLevel);
		}
	}
}