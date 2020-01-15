namespace Strategy
{
	public class ExactComparer : NameComparer
	{
		public override bool Compare(string name1, FullName record)
		{
			var recordName = record.FirstName + " " + record.LastName;
			return recordName == name1;
		}
	}
}