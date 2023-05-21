using System.Text.Json;
using ConvertMaterial.Binary;
using ConvertMaterial.Models;

namespace ConvertMaterial
{
	public class JsonToMaterialConverter : IConverter
	{
		private string input;
		private string output;

		public JsonToMaterialConverter(string input, string output)
		{
			this.input = input;
			this.output = output;
		}

		public void Convert()
		{
			Material data = null;

			// Read JSON
			using (var filestream = File.OpenRead(input))
			{
				var doc = JsonDocument.Parse(filestream);

				doc.RootElement.TryGetProperty("MaterialType", out var prop);

				var matType = Enum.TryParse<MaterialType>(
					prop.ToString(), 
					true, 
					out MaterialType result) ? result : MaterialType.None;

				data = matType switch {
					MaterialType.BGEM => doc.Deserialize<BGEM>(),
					MaterialType.BGSM => doc.Deserialize<BGSM>(),
					_ => throw new FormatException("Unknown material type.")
				};
			}

			// If output path is empty, generate one from input path
			if (string.IsNullOrEmpty(output))
			{
				output = Path.ChangeExtension(input, Enum.GetName(data.MaterialType));
			}

			// Write binary
			using (var filestream = File.Create(output))
			{
				using var writer = new BinaryWriter(filestream);

				if (data.MaterialType == MaterialType.BGEM)
				{
					var ser = new BGEMSerializer();
					ser.Serialize(writer, data as ConvertMaterial.Models.BGEM);
				}
				else if (data.MaterialType == MaterialType.BGSM)
				{
					var ser = new BGSMSerializer();
					ser.Serialize(writer, data as ConvertMaterial.Models.BGSM);
				}
				else
				{
					throw new FormatException("Unknown material type.");
				}

				writer.Flush();
			}
		}
	}
}