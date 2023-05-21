using ConvertMaterial.Models;

namespace ConvertMaterial.Binary
{
	public class BGSMDeserializer : BaseDeserializer
	{
		public BGSM Deserialize(BinaryReader input)
		{
			var material = new BGSM();
			base.Deserialize(input, material);

			material.DiffuseTexture = ReadString(input);
			material.NormalTexture = ReadString(input);
			material.SmoothSpecTexture = ReadString(input);
			material.GreyscaleTexture = ReadString(input);

			if (material.Version > 2)
			{
				material.GlowTexture = ReadString(input);
				material.WrinklesTexture = ReadString(input);
				material.SpecularTexture = ReadString(input);
				material.LightingTexture = ReadString(input);
				material.FlowTexture = ReadString(input);
				if (material.Version >= 17) material.DistanceFieldAlphaTexture = ReadString(input);
			}
			else
			{
				material.EnvmapTexture = ReadString(input);
				material.GlowTexture = ReadString(input);
				material.InnerLayerTexture = ReadString(input);
				material.WrinklesTexture = ReadString(input);
				material.DisplacementTexture = ReadString(input);
			}

			material.EnableEditorAlphaRef = input.ReadBoolean();

			if (material.Version >= 8)
			{
				material.Translucency = input.ReadBoolean();
				material.TranslucencyThickObject = input.ReadBoolean();
				material.TranslucencyMixAlbedoWithSubsurfaceColor = input.ReadBoolean();
				material.TranslucencySubsurfaceColor = ReadColor(input);
				material.TranslucencyTransmissiveScale = input.ReadSingle();
				material.TranslucencyTurbulence = input.ReadSingle();
			}
			else
			{
				material.RimLighting = input.ReadBoolean();
				material.RimPower = input.ReadSingle();
				material.BackLightPower = input.ReadSingle();
				material.SubsurfaceLighting = input.ReadBoolean();
				material.SubsurfaceLightingRolloff = input.ReadSingle();
			}

			material.SpecularEnabled = input.ReadBoolean();
			material.SpecularColor = ReadColor(input);
			material.SpecularMult = input.ReadSingle();
			material.Smoothness = input.ReadSingle();
			material.FresnelPower = input.ReadSingle();
			material.WetnessControlSpecScale = input.ReadSingle();
			material.WetnessControlSpecPowerScale = input.ReadSingle();
			material.WetnessControlSpecMinvar = input.ReadSingle();

			if (material.Version < 10)
			{
				material.WetnessControlEnvMapScale = input.ReadSingle();
			}

			material.WetnessControlFresnelPower = input.ReadSingle();
			material.WetnessControlMetalness = input.ReadSingle();

			if (material.Version > 2)
			{
				material.PBR = input.ReadBoolean();

				if (material.Version >= 9)
				{
					material.CustomPorosity = input.ReadBoolean();
					material.PorosityValue = input.ReadSingle();
				}
			}

			material.RootMaterialPath = ReadString(input);
			material.AnisoLighting = input.ReadBoolean();
			material.EmitEnabled = input.ReadBoolean();

			if (material.EmitEnabled)
			{
				material.EmittanceColor = ReadColor(input);
			}

			material.EmittanceMult = input.ReadSingle();
			material.ModelSpaceNormals = input.ReadBoolean();
			material.ExternalEmittance = input.ReadBoolean();

			if (material.Version >= 12)
			{
				material.LumEmittance = input.ReadSingle();
			}

			if (material.Version >= 13)
			{
				material.UseAdaptativeEmissive = input.ReadBoolean();
				material.AdaptativeEmissive_ExposureOffset = input.ReadSingle();
				material.AdaptativeEmissive_FinalExposureMin = input.ReadSingle();
				material.AdaptativeEmissive_FinalExposureMax = input.ReadSingle();
			}

			if (material.Version < 8)
			{
				material.BackLighting = input.ReadBoolean();
			}

			material.ReceiveShadows = input.ReadBoolean();
			material.HideSecret = input.ReadBoolean();
			material.CastShadows = input.ReadBoolean();
			material.DissolveFade = input.ReadBoolean();
			material.AssumeShadowmask = input.ReadBoolean();
			material.Glowmap = input.ReadBoolean();

			if (material.Version < 7)
			{
				material.EnvironmentMappingWindow = input.ReadBoolean();
				material.EnvironmentMappingEye = input.ReadBoolean();
			}

			material.Hair = input.ReadBoolean();
			material.HairTintColor = ReadColor(input);
			material.Tree = input.ReadBoolean();
			material.Facegen = input.ReadBoolean();
			material.SkinTint = input.ReadBoolean();
			material.Tessellate = input.ReadBoolean();

			if (material.Version < 3)
			{
				material.DisplacementTextureBias = input.ReadSingle();
				material.DisplacementTextureScale = input.ReadSingle();
				material.TessellationPnScale = input.ReadSingle();
				material.TessellationBaseFactor = input.ReadSingle();
				material.TessellationFadeDistance = input.ReadSingle();
			}

			material.GrayscaleToPaletteScale = input.ReadSingle();

			if (material.Version >= 1)
			{
				material.SkewSpecularAlpha = input.ReadBoolean();
			}

			if (material.Version >= 3)
			{
				material.Terrain = input.ReadBoolean();

				if (material.Terrain)
				{
					if (material.Version == 3) material.UnkInt1 = input.ReadUInt32();
					material.TerrainThresholdFalloff = input.ReadSingle();
					material.TerrainTilingDistance = input.ReadSingle();
					material.TerrainRotationAngle = input.ReadSingle();
				}
			}

			return material;
		}
	}
}