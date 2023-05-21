using ConvertMaterial.Models;

namespace ConvertMaterial.Binary
{
	public class BGSMSerializer : BaseSerializer
	{
		public void Serialize(BinaryWriter output, BGSM material)
		{
			base.Serialize(output, material);

			WriteString(output, material.DiffuseTexture);
			WriteString(output, material.NormalTexture);
			WriteString(output, material.SmoothSpecTexture);
			WriteString(output, material.GreyscaleTexture);

			if (material.Version > 2)
			{
				WriteString(output, material.GlowTexture);
				WriteString(output, material.WrinklesTexture);
				WriteString(output, material.SpecularTexture);
				WriteString(output, material.LightingTexture);
				WriteString(output, material.FlowTexture);

				if (material.Version >= 17)
				{
					WriteString(output, material.DistanceFieldAlphaTexture);
				}
			}
			else
			{
				WriteString(output, material.EnvmapTexture);
				WriteString(output, material.GlowTexture);
				WriteString(output, material.InnerLayerTexture);
				WriteString(output, material.WrinklesTexture);
				WriteString(output, material.DisplacementTexture);
			}

			output.Write(material.EnableEditorAlphaRef);

			if (material.Version >= 8)
			{
				output.Write(material.Translucency);
				output.Write(material.TranslucencyThickObject);
				output.Write(material.TranslucencyMixAlbedoWithSubsurfaceColor);
				WriteColor(output, material.TranslucencySubsurfaceColor);
				output.Write(material.TranslucencyTransmissiveScale);
				output.Write(material.TranslucencyTurbulence);
			}
			else
			{
				output.Write(material.RimLighting);
				output.Write(material.RimPower);
				output.Write(material.BackLightPower);

				output.Write(material.SubsurfaceLighting);
				output.Write(material.SubsurfaceLightingRolloff);
			}

			output.Write(material.SpecularEnabled);
			WriteColor(output, material.SpecularColor);
			output.Write(material.SpecularMult);
			output.Write(material.Smoothness);
			output.Write(material.FresnelPower);
			output.Write(material.WetnessControlSpecScale);
			output.Write(material.WetnessControlSpecPowerScale);
			output.Write(material.WetnessControlSpecMinvar);

			if (material.Version < 10)
			{
				output.Write(material.WetnessControlEnvMapScale);
			}

			output.Write(material.WetnessControlFresnelPower);
			output.Write(material.WetnessControlMetalness);

			if (material.Version > 2)
			{
				output.Write(material.PBR);

				if (material.Version >= 9)
				{
					output.Write(material.CustomPorosity);
					output.Write(material.PorosityValue);
				}
			}

			WriteString(output, material.RootMaterialPath);
			output.Write(material.AnisoLighting);
			output.Write(material.EmitEnabled);

			if (material.EmitEnabled)
			{
				WriteColor(output, material.EmittanceColor);
			}

			output.Write(material.EmittanceMult);
			output.Write(material.ModelSpaceNormals);
			output.Write(material.ExternalEmittance);

			if (material.Version >= 12)
			{
				output.Write(material.LumEmittance);
			}

			if (material.Version >= 13)
			{
				output.Write(material.UseAdaptativeEmissive);
				output.Write(material.AdaptativeEmissive_ExposureOffset);
				output.Write(material.AdaptativeEmissive_FinalExposureMin);
				output.Write(material.AdaptativeEmissive_FinalExposureMax);
			}

			if (material.Version < 8)
			{
				output.Write(material.BackLighting);
			}

			output.Write(material.ReceiveShadows);
			output.Write(material.HideSecret);
			output.Write(material.CastShadows);
			output.Write(material.DissolveFade);
			output.Write(material.AssumeShadowmask);
			output.Write(material.Glowmap);

			if (material.Version < 7)
			{
				output.Write(material.EnvironmentMappingWindow);
				output.Write(material.EnvironmentMappingEye);
			}

			output.Write(material.Hair);
			WriteColor(output, material.HairTintColor);
			output.Write(material.Tree);
			output.Write(material.Facegen);
			output.Write(material.SkinTint);
			output.Write(material.Tessellate);

			if (material.Version < 3)
			{
				output.Write(material.DisplacementTextureBias);
				output.Write(material.DisplacementTextureScale);
				output.Write(material.TessellationPnScale);
				output.Write(material.TessellationBaseFactor);
				output.Write(material.TessellationFadeDistance);
			}

			output.Write(material.GrayscaleToPaletteScale);

			if (material.Version >= 1)
			{
				output.Write(material.SkewSpecularAlpha);
			}

			if (material.Version >= 3)
			{
				output.Write(material.Terrain);

				if (material.Terrain)
				{
					if (material.Version == 3)
					{
						output.Write(material.UnkInt1);
					}

					output.Write(material.TerrainThresholdFalloff);
					output.Write(material.TerrainTilingDistance);
					output.Write(material.TerrainRotationAngle);
				}
			}

		}
	}
}