using System.Collections.Generic;
using System.Linq;

namespace Memento
{
	public class DocumentHistory
	{
		private List<object> _history = new List<object>();

		private Document _document;

		public DocumentHistory(Document document)
		{
			_document = document;
		}

		public void SnapShot()
		{
			var memento = _document.SaveState();
			_history.Add(memento);
		}

		public void Restore(int historyIndex)
		{
			var memento = _history.ElementAtOrDefault(historyIndex);
			
			if (memento != null)
				_document.LoadState(memento);
		}
	}
}