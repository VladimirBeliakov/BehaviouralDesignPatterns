using System.IO;

namespace TemplateMethod
{
	public abstract class FileWriter
	{
		protected string Path;
		
		protected abstract void DecryptFile();

		protected virtual void AppendData(string data)
		{
			using (var fs = File.Open(Path, FileMode.Append))
			using (var tw = new StreamWriter(fs))
				tw.Write(data);
		}

		protected abstract void EncryptFile();

		public void Append(string data)
		{
			DecryptFile();
			AppendData(data);
			EncryptFile();
		}
	}
}