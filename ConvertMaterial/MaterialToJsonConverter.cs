using System.Text.Json;
using ConvertMaterial.Binary;
using ConvertMaterial.Models;

namespace ConvertMaterial
{
	public record class MaterialToJsonConverter : IConverter
	{
		private string input;
		private string output;

		public MaterialToJsonConverter(string input, string output)
		{
			this.input = input;
			this.output = output;
		}

		public void Convert()
		{
			Material data = null;

			// Read binary
			using (var filestream = File.OpenRead(input))
			{
				using var reader = new BinaryReader(filestream);

				var header = (MaterialType)reader.ReadUInt32();

				data = (header) switch
				{
					MaterialType.BGEM => new BGEMDeserializer().Deserialize(reader),
					MaterialType.BGSM => new BGSMDeserializer().Deserialize(reader),
					_ => throw new FormatException("Unknown material type.")
				};
			}

			// If output path is empty, generate one from input path
			if (string.IsNullOrEmpty(output))
			{
				output = Path.ChangeExtension(input, "json");
			}

			// Write JSON
			using (var filestream = File.Create(output))
			{
				JsonSerializer.Serialize(filestream, data, data.GetType(), new JsonSerializerOptions { WriteIndented = true });
			}
		}
	}
}