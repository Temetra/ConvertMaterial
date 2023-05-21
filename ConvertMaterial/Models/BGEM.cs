using System.Text.Json.Serialization;

namespace ConvertMaterial.Models
{
	public class BGEM : Material
	{
		public BGEM()
		{
			this.MaterialType = MaterialType.BGEM;
		}

		public string BaseTexture { get; set; }
		public string GrayscaleTexture { get; set; }
		public string EnvmapTexture { get; set; }
		public string NormalTexture { get; set; }
		public string EnvmapMaskTexture { get; set; }
		public string SpecularTexture { get; set; }
		public string LightingTexture { get; set; }
		public string GlowTexture { get; set; }
		public bool BloodEnabled { get; set; }
		public bool EffectLightingEnabled { get; set; }
		public bool FalloffEnabled { get; set; }
		public bool FalloffColorEnabled { get; set; }
		public bool GrayscaleToPaletteAlpha { get; set; }
		public bool SoftEnabled { get; set; }
		[JsonConverter(typeof(Json.HexColorConverter))]
		public Color BaseColor { get; set; } = Color.FromUInt32(0xFFFFFFFFu);
		public float BaseColorScale { get; set; } = 1.0f;
		public float FalloffStartAngle { get; set; } = 1.0f;
		public float FalloffStopAngle { get; set; } = 1.0f;
		public float FalloffStartOpacity { get; set; }
		public float FalloffStopOpacity { get; set; }
		public float LightingInfluence { get; set; } = 1.0f;
		public byte EnvmapMinLOD { get; set; }
		public float SoftDepth { get; set; } = 100.0f;
		[JsonConverter(typeof(Json.HexColorConverter))]
		public Color EmittanceColor { get; set; } = Color.FromUInt32(0xFFFFFFFFu);
		public float AdaptativeEmissive_ExposureOffset { get; set; }
		public float AdaptativeEmissive_FinalExposureMin { get; set; }
		public float AdaptativeEmissive_FinalExposureMax { get; set; }
		public bool Glowmap { get; set; }
		public bool EffectPbrSpecular { get; set; }
	}
}