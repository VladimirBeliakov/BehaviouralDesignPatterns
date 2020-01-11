using System;
using System.Threading;

namespace Observer
{
	public class Timer
	{
		public delegate void NotifyEvent<in T>(T subject, EventArgs args);

		public event NotifyEvent<Timer> Notify;
		
		public void Start()
		{
			var thread = new Thread(
				() =>
				{
					while (true)
					{
						Notify?.Invoke(this, new EventArgs());
						Thread.Sleep(1000);
					}
				}
			);

			thread.Start();
		}
	}
}