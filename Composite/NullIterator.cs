using System.Collections;
using System.Collections.Generic;

namespace Composite
{
	public class NullIterator<T> : IEnumerator<T>
	{
		public NullIterator(T item)
		{
			Current = item;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
			throw new System.NotImplementedException();
		}

		public T Current { get; }

		object IEnumerator.Current => Current;
	}
}