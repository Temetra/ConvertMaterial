namespace ConvertMaterial.Json
{
	public static class JsonHelper
	{
		public static bool FileIsJson(string filename)
		{
			if (string.IsNullOrEmpty(filename)) return false;

			char header;

			using (var filestream = File.OpenRead(filename))
			{
				using var reader = new BinaryReader(filestream);
				header = reader.ReadChar();
			}

			return header == '{';
		}
	}
}