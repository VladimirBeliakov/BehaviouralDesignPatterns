using System;

namespace Observer
{
	public class ConsoleClock
	{
		public void Update(Timer sender, EventArgs args)
		{
			Console.WriteLine(DateTime.UtcNow.TimeOfDay);
		}
	}
}