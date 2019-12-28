using System.Collections.Generic;

namespace Composite
{
	public interface IMenuComponent : IEnumerable<IMenuComponent>
	{
		string GetName();
		string GetDescription();
		decimal GetPrice();
		bool IsVegetarian();
		void Print();
		void Add(IMenuComponent component);
		void Remove(IMenuComponent component);
		IMenuComponent TryGetChild(int index);
		IEnumerable<IMenuComponent> GetMenuItems();
	}
}