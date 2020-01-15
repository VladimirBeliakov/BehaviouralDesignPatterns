using System.Threading;

namespace Strategy
{
	public abstract class NameComparer
	{
		public abstract bool Compare(string name1, FullName record);
	}
}