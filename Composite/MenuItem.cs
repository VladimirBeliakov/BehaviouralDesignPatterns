using System;
using System.Collections.Generic;

namespace Composite
{
	public class MenuItem : MenuComponent
	{
		private readonly string _description;
		private readonly string _name;
		private readonly decimal _price;
		private readonly bool _isVegetarian;

		public MenuItem(string description, string name, decimal price, bool isVegetarian)
		{
			_description = description;
			_name = name;
			_price = price;
			_isVegetarian = isVegetarian;
		}

		public override string GetName()
		{
			return _name;
		}

		public override string GetDescription()
		{
			return _description;
		}

		public override decimal GetPrice()
		{
			return _price;
		}

		public override bool IsVegetarian()
		{
			return _isVegetarian;
		}

		public override void Print()
		{
			Console.WriteLine($"{_name} {(_isVegetarian ? "(v)" : "")}, {_price}, {_description}");
		}

		public override IEnumerable<IMenuComponent> GetMenuItems()
		{
			return Array.Empty<IMenuComponent>();
		}

		public override IEnumerator<IMenuComponent> GetEnumerator()
		{
			return new NullIterator<IMenuComponent>(this);
		}
	}
}