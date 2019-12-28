using System;
using System.Threading;

namespace Program
{
	// Instances can be marshaled-by-value across AppDomain boundaries
	[Serializable]
	public sealed class MarshalByValType : Object
	{
		private DateTime m_creationTime = DateTime.Now; // NOTE: DateTime is [Serializable]

		public MarshalByValType()
		{
			Console.WriteLine("{0} ctor running in {1}, Created on {2:D}",
				this.GetType().ToString(),
				Thread.GetDomain().FriendlyName,
				m_creationTime);
		}

		public override String ToString()
		{
			return m_creationTime.ToLongDateString();
		}
	}
}