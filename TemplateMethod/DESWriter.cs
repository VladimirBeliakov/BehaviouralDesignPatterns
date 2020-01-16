using System;

namespace TemplateMethod
{
	public class DESWriter : FileWriter
	{
		private const string _key = "1234"; 

		public DESWriter(string filePath)
		{
			Path = filePath;
		}

		protected override void DecryptFile()
		{
			Console.WriteLine("Decrypting the file using the DES method.");
		}

		protected override void AppendData(string data)
		{
			Console.WriteLine("Appending the data to a file");
		}

		protected override void EncryptFile()
		{
			Console.WriteLine("Encrypting the file using the DES method.");
		}
	}
}