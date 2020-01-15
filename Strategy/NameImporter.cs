using System;

namespace Strategy
{
	public class NameImporter
	{
		private readonly NameComparer _nameComparer;

		public NameImporter(NameComparer nameComparer)
		{
			_nameComparer = nameComparer;
		}

		public void Match(FullName[] fullNames, string[] importList)
		{
			foreach (var fullName in fullNames)
			{
				foreach (var item in importList)
				{
					if (_nameComparer.Compare(item, fullName))
					{
						Console.WriteLine($"{item} - {fullName.FirstName} {fullName.LastName}");
						break;
					}
				}
			}
		}
	}
}