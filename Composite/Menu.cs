using System;
using System.Collections.Generic;
using System.Linq;

namespace Composite
{
	public class Menu : MenuComponent
	{
		private readonly List<IMenuComponent> _menuComponents = new List<IMenuComponent>();
		private readonly string _name;
		private readonly string _description;

		public Menu(string name, string description)
		{
			_name = name;
			_description = description;
		}

		public override void Add(IMenuComponent component)
		{
			_menuComponents.Add(component);
		}

		public override void Remove(IMenuComponent component)
		{
			_menuComponents.Remove(component);
		}

		public override string GetName()
		{
			return _name;
		}

		public override string GetDescription()
		{
			return _description;
		}

		public override IMenuComponent TryGetChild(int i)
		{
			return _menuComponents.ElementAtOrDefault(i);
		}

		public override void Print()
		{
			Console.WriteLine($"{_name}, {_description}");
			Console.WriteLine("menu items:");

			foreach (var menuComponent in this)
				menuComponent.Print();

			Console.WriteLine("-----------------------------");
		}

		public override IEnumerable<IMenuComponent> GetMenuItems()
		{
			return _menuComponents;
		}

		public override IEnumerator<IMenuComponent> GetEnumerator()
		{
			return new CompositeIterator(_menuComponents);
		}
	}
}