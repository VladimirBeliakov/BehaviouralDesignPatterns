using System;
using System.Text.RegularExpressions;

namespace Strategy
{
	public class FuzzyComparer : NameComparer
	{
		public override bool Compare(string name1, FullName record)
		{
			var names = CleanAndSplitFullName(name1);

			return FuzzyCompare(names, record);
		}

		protected string[] CleanAndSplitFullName(string fullName)
		{
			var trimmedName = fullName.Trim();

			var regex = new Regex(@"[^A-Za-z\s\.\-]");

			var cleanedName = regex.Replace(trimmedName, "");

			regex = new Regex(@"([\s]{2,}|[\-])");
			cleanedName = regex.Replace(cleanedName, " ");

			return cleanedName.Split(' ');
		}

		protected bool FuzzyCompare(string[] names, FullName record)
		{
			return names.Length == 2 &&
				   string.Equals(names[0], record.FirstName, StringComparison.InvariantCulture) &&
				   string.Equals(names[1], record.LastName, StringComparison.InvariantCulture);
		}
	}

	public class AbbreviationComparer : FuzzyComparer
	{
		public override bool Compare(string name1, FullName record)
		{
			var names = CleanAndSplitFullName(name1);

			if (names.Length == 2)
			{
				var pos = names[0].IndexOf(".", StringComparison.InvariantCulture);

				if (pos >= 0)
				{
					var abbreviatedFirstName = names[0].Substring(0, pos);
					var abbreviatedRecord = record.FirstName.Substring(0, pos);

					return string.Equals(abbreviatedFirstName, abbreviatedRecord, StringComparison.InvariantCulture) &&
						   string.Equals(names[1], record.LastName, StringComparison.InvariantCulture);
				}

				return FuzzyCompare(names, record);
			}

			return false;
		}
	}
}