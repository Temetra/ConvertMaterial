using System.Text.Json;
using System.Text.Json.Serialization;
using ConvertMaterial.Models;

namespace ConvertMaterial.Json
{
	public class MaterialTypeConverter : JsonConverter<MaterialType>
	{
		public override MaterialType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
			Enum.TryParse<MaterialType>(reader.GetString(), true, out MaterialType result) ? result : MaterialType.None;

		public override void Write(Utf8JsonWriter writer, MaterialType value, JsonSerializerOptions options) =>
			writer.WriteStringValue(Enum.GetName(value));
	}
}