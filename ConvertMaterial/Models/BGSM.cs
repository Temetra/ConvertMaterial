using System.Text.Json.Serialization;

namespace ConvertMaterial.Models
{
	public class BGSM : Material
	{
		public BGSM()
		{
			this.MaterialType = MaterialType.BGSM;
		}

		public string DiffuseTexture { get; set; } = "";
		public string NormalTexture { get; set; } = "";
		public string SmoothSpecTexture { get; set; } = "";
		public string GreyscaleTexture { get; set; } = "";
		public string EnvmapTexture { get; set; } = "";
		public string GlowTexture { get; set; } = "";
		public string InnerLayerTexture { get; set; } = "";
		public string WrinklesTexture { get; set; } = "";
		public string DisplacementTexture { get; set; } = "";
		public string SpecularTexture { get; set; } = "";
		public string LightingTexture { get; set; } = "";
		public string FlowTexture { get; set; } = "";
		public string DistanceFieldAlphaTexture { get; set; } = "";
		public bool EnableEditorAlphaRef { get; set; }
		public bool RimLighting { get; set; }
		public float RimPower { get; set; } = 2.0f;
		public float BackLightPower { get; set; }
		public bool SubsurfaceLighting { get; set; }
		public float SubsurfaceLightingRolloff { get; set; } = 0.3f;
		public bool SpecularEnabled { get; set; }
		[JsonConverter(typeof(Json.HexColorConverter))]
		public Color SpecularColor { get; set; } = Color.FromUInt32(0xFFFFFFFFu);
		public float SpecularMult { get; set; } = 1.0f;
		public float Smoothness { get; set; } = 1.0f;
		public float FresnelPower { get; set; } = 5.0f;
		public float WetnessControlSpecScale { get; set; } = -1.0f;
		public float WetnessControlSpecPowerScale { get; set; } = -1.0f;
		public float WetnessControlSpecMinvar { get; set; } = -1.0f;
		public float WetnessControlEnvMapScale { get; set; } = -1.0f;
		public float WetnessControlFresnelPower { get; set; } = -1.0f;
		public float WetnessControlMetalness { get; set; } = -1.0f;
		public string RootMaterialPath { get; set; } = "";
		public bool AnisoLighting { get; set; }
		public bool EmitEnabled { get; set; }
		[JsonConverter(typeof(Json.HexColorConverter))]
		public Color EmittanceColor { get; set; } = Color.FromUInt32(0xFFFFFFFFu);
		public float EmittanceMult { get; set; } = 1.0f;
		public bool ModelSpaceNormals { get; set; }
		public bool ExternalEmittance { get; set; }
		public bool BackLighting { get; set; }
		public bool ReceiveShadows { get; set; }
		public bool HideSecret { get; set; }
		public bool CastShadows { get; set; }
		public bool DissolveFade { get; set; }
		public bool AssumeShadowmask { get; set; }
		public bool Glowmap { get; set; }
		public bool EnvironmentMappingWindow { get; set; }
		public bool EnvironmentMappingEye { get; set; }
		public bool Hair { get; set; }
		[JsonConverter(typeof(Json.HexColorConverter))]
		public Color HairTintColor { get; set; } = Color.FromUInt32(0x808080u);
		public bool Tree { get; set; }
		public bool Facegen { get; set; }
		public bool SkinTint { get; set; }
		public bool Tessellate { get; set; }
		public float DisplacementTextureBias { get; set; } = -0.5f;
		public float DisplacementTextureScale { get; set; } = 10.0f;
		public float TessellationPnScale { get; set; } = 1.0f;
		public float TessellationBaseFactor { get; set; } = 1.0f;
		public float TessellationFadeDistance { get; set; }
		public float GrayscaleToPaletteScale { get; set; } = 1.0f;
		public bool SkewSpecularAlpha { get; set; }
		public bool Translucency { get; set; }
		[JsonConverter(typeof(Json.HexColorConverter))]
		public Color TranslucencySubsurfaceColor { get; set; }
		public float TranslucencyTransmissiveScale { get; set; }
		public float TranslucencyTurbulence { get; set; }
		public bool PBR { get; set; }
		public bool CustomPorosity { get; set; }
		public float PorosityValue { get; set; }
		public float LumEmittance { get; set; }
		public bool TranslucencyThickObject { get; set; }
		public bool TranslucencyMixAlbedoWithSubsurfaceColor { get; set; }
		public bool UseAdaptativeEmissive { get; set; }
		public float AdaptativeEmissive_ExposureOffset { get; set; }
		public float AdaptativeEmissive_FinalExposureMin { get; set; }
		public float AdaptativeEmissive_FinalExposureMax { get; set; }
		public bool Terrain { get; set; }
		public float TerrainThresholdFalloff { get; set; }
		public float TerrainTilingDistance { get; set; }
		public float TerrainRotationAngle { get; set; }
		public uint UnkInt1 { get; set; }
	}
}