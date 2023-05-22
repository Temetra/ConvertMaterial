using ConvertMaterial.Models;

namespace ConvertMaterial
{
	public static class Transform
	{
		public static void FromJsonToBinary(string input, string output)
		{
			Material data = null;

			// Read JSON
			using (var filestream = File.OpenRead(input))
			{
				data = filestream.ReadJsonMaterial();
			}

			// If output path is empty, generate one from input path
			if (string.IsNullOrEmpty(output))
			{
				output = Path.ChangeExtension(input, Enum.GetName(data.MaterialType));
			}

			// Write binary
			using (var filestream = File.Create(output))
			{
				filestream.WriteBinaryMaterial(data);
			}
		}

		public static void FromBinaryToJson(string input, string output)
		{
			Material data = null;

			// Read binary
			using (var filestream = File.OpenRead(input))
			{
				data = filestream.ReadBinaryMaterial();
			}

			// If output path is empty, generate one from input path
			if (string.IsNullOrEmpty(output))
			{
				output = Path.ChangeExtension(input, "json");
			}

			// Write JSON
			using (var filestream = File.Create(output))
			{
				filestream.WriteJsonMaterial(data);
			}
		}

	}
}