using System.Text.Json;
using ConvertMaterial.Binary;
using ConvertMaterial.Models;

namespace ConvertMaterial
{
	public static class MaterialIO
	{
		public static Material ReadJsonMaterial(this Stream stream)
		{
			var doc = JsonDocument.Parse(stream);

			doc.RootElement.TryGetProperty("MaterialType", out var prop);

			var matType = Enum.TryParse<MaterialType>(
				prop.ToString(), 
				true, 
				out MaterialType result) ? result : MaterialType.None;

			return matType switch {
				MaterialType.BGEM => doc.Deserialize<BGEM>(),
				MaterialType.BGSM => doc.Deserialize<BGSM>(),
				_ => throw new FormatException("Unknown material type.")
			};
		}

		public static void WriteJsonMaterial(this Stream stream, Material material)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			JsonSerializer.Serialize(stream, material, material.GetType(), options);
		}

		public static Material ReadBinaryMaterial(this Stream stream)
		{
			using var reader = new BinaryReader(stream);

			var header = (MaterialType)reader.ReadUInt32();

			return (header) switch
			{
				MaterialType.BGEM => new BGEMDeserializer().Deserialize(reader),
				MaterialType.BGSM => new BGSMDeserializer().Deserialize(reader),
				_ => throw new FormatException("Unknown material type.")
			};
		}

		public static void WriteBinaryMaterial(this Stream stream, Material material)
		{
			using var writer = new BinaryWriter(stream);

			if (material.MaterialType == MaterialType.BGEM)
			{
				var ser = new BGEMSerializer();
				ser.Serialize(writer, material as ConvertMaterial.Models.BGEM);
			}
			else if (material.MaterialType == MaterialType.BGSM)
			{
				var ser = new BGSMSerializer();
				ser.Serialize(writer, material as ConvertMaterial.Models.BGSM);
			}
			else
			{
				throw new FormatException("Unknown material type.");
			}

			writer.Flush();
		}
	}
}