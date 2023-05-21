using System.Text.Json;
using System.Text.Json.Serialization;
using ConvertMaterial.Models;

namespace ConvertMaterial.Json
{
	public class HexColorConverter : JsonConverter<Color>
	{
		public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
			Color.FromHexString(reader.GetString());

		public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options) =>
			writer.WriteStringValue(value.ToHexString());
	}
}