using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Composite
{
	public abstract class MenuComponent : IMenuComponent
	{
		public virtual string GetName()
		{
			throw new System.NotImplementedException();
		}

		public virtual string GetDescription()
		{
			throw new System.NotImplementedException();
		}

		public virtual decimal GetPrice()
		{
			throw new System.NotImplementedException();
		}

		public virtual bool IsVegetarian()
		{
			throw new System.NotImplementedException();
		}

		public virtual void Print()
		{
			throw new System.NotImplementedException();
		}

		public virtual void Add(IMenuComponent component)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Remove(IMenuComponent component)
		{
			throw new System.NotImplementedException();
		}

		public virtual IMenuComponent TryGetChild(int index)
		{
			throw new System.NotImplementedException();
		}

		public virtual IEnumerable<IMenuComponent> GetMenuItems()
		{
			throw new System.NotImplementedException();
		}

		public virtual IEnumerator<IMenuComponent> GetEnumerator()
		{
			throw new System.NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}