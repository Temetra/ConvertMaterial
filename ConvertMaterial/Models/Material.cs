using System.Text.Json.Serialization;

namespace ConvertMaterial.Models
{
	public abstract class Material
	{
		[JsonConverter(typeof(Json.MaterialTypeConverter))]
		public MaterialType MaterialType { get; set; }
		public uint Version { get; set; } = 2;
		public bool TileU { get; set; } = true;
		public bool TileV { get; set; } = true;
		public float UOffset { get; set; }
		public float VOffset { get; set; }
		public float UScale { get; set; } = 1.0f;
		public float VScale { get; set; } = 1.0f;
		public float Alpha { get; set; } = 1.0f;
		[JsonConverter(typeof(Json.AlphaBlendModeTypeConverter))]
		public AlphaBlendModeType AlphaBlendMode { get; set; }
		public byte AlphaTestRef { get; set; } = 128;
		public bool AlphaTest { get; set; }
		public bool ZBufferWrite { get; set; } = true;
		public bool ZBufferTest { get; set; } = true;
		public bool ScreenSpaceReflections { get; set; }
		public bool WetnessControlScreenSpaceReflections { get; set; }
		public bool Decal { get; set; }
		public bool TwoSided { get; set; }
		public bool DecalNoFade { get; set; }
		public bool NonOccluder { get; set; }
		public bool Refraction { get; set; }
		public bool RefractionFalloff { get; set; }
		public float RefractionPower { get; set; }
		public bool EnvironmentMapping { get; set; }
		public float EnvironmentMappingMaskScale { get; set; } = 1.0f;
		public bool DepthBias { get; set; }
		public bool GrayscaleToPaletteColor { get; set; }
		[JsonIgnore]
		public MaskWriteFlags MaskWrites { get; set; } = MaskWriteFlags.Albedo | MaskWriteFlags.Normal | MaskWriteFlags.Specular | MaskWriteFlags.AmbientOcclusion | MaskWriteFlags.Emissive | MaskWriteFlags.Gloss;

		public bool WriteMaskAlbedo
		{
			get { return MaskWrites.HasFlag(MaskWriteFlags.Albedo); }
			set { MaskWrites |= MaskWriteFlags.Albedo; }
		}

		public bool WriteMaskNormal
		{
			get { return MaskWrites.HasFlag(MaskWriteFlags.Normal); }
			set { MaskWrites |= MaskWriteFlags.Normal; }
		}

		public bool WriteMaskSpecular
		{
			get { return MaskWrites.HasFlag(MaskWriteFlags.Specular); }
			set { MaskWrites |= MaskWriteFlags.Specular; }
		}

		public bool WriteMaskAmbientOcclusion
		{
			get { return MaskWrites.HasFlag(MaskWriteFlags.AmbientOcclusion); }
			set { MaskWrites |= MaskWriteFlags.AmbientOcclusion; }
		}

		public bool WriteMaskEmissive
		{
			get { return MaskWrites.HasFlag(MaskWriteFlags.Emissive); }
			set { MaskWrites |= MaskWriteFlags.Emissive; }
		}

		public bool WriteMaskGloss
		{
			get { return MaskWrites.HasFlag(MaskWriteFlags.Gloss); }
			set { MaskWrites |= MaskWriteFlags.Gloss; }
		}
	}
}