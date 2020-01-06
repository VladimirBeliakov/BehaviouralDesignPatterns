namespace Memento
{
	public class Document
	{
		private sealed class DocumentState
		{
			public DocumentState(string state)
			{
				State = state;
			}

			public string State { get; }
		}

		private string _html;

		public void Append(string text)
		{
			_html += text;
		}

		public void Italic()
		{
			_html = "<i>" + _html + "</i>";
		}

		public void Bold()
		{
			_html = "<b>" + _html + "</b>";
		}

		public object SaveState()
		{
			return new DocumentState(_html);
		}

		public void LoadState(object state)
		{
			_html = state is DocumentState documentState ? documentState.State : _html;
		}

		public override string ToString()
		{
			return _html;
		}
	}
}