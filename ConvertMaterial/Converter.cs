namespace ConvertMaterial
{
	public interface IConverter
	{
		public void Convert();
	}

	public static class Converter
	{
		public static IConverter GetConverter(string input, string output)
		{
			if (string.IsNullOrEmpty(input)) return null;

			char header;

			using (var filestream = File.OpenRead(input))
			{
				using var reader = new BinaryReader(filestream);
				header = reader.ReadChar();
			}

			if (header == '{') return new JsonToMaterialConverter(input, output);
			else return new MaterialToJsonConverter(input, output);
		}
	}
}