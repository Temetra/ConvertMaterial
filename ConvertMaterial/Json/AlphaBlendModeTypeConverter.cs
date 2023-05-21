using System.Text.Json;
using System.Text.Json.Serialization;
using ConvertMaterial.Models;

namespace ConvertMaterial.Json
{
	public class AlphaBlendModeTypeConverter : JsonConverter<AlphaBlendModeType>
	{
		public override AlphaBlendModeType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => 
			Enum.TryParse<AlphaBlendModeType>(reader.GetString(), true, out AlphaBlendModeType result) ? result : AlphaBlendModeType.None;

		public override void Write(Utf8JsonWriter writer, AlphaBlendModeType value, JsonSerializerOptions options) =>
			writer.WriteStringValue(Enum.GetName(value));
	}
}