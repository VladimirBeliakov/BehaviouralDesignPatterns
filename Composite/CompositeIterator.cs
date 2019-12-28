using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
	public class CompositeIterator : IEnumerator<IMenuComponent>
	{
		private readonly IReadOnlyCollection<IMenuComponent> _menuComponents;

		private int _currentIndex;

		public CompositeIterator(IReadOnlyCollection<IMenuComponent> menuComponents)
		{
			_menuComponents = menuComponents;
		}
		
		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			var nextElement = _menuComponents.ElementAtOrDefault(_currentIndex++);

			if (nextElement is null)
				return false;

			Current = nextElement;
			return true;
		}

		public void Reset()
		{
			_currentIndex = 0;
		}

		public IMenuComponent Current { get; private set; }

		object IEnumerator.Current => Current;
	}
}