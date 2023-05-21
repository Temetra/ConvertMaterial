using ConvertMaterial.Models;

namespace ConvertMaterial.Binary
{
	public class BGEMSerializer : BaseSerializer
	{
		public void Serialize(BinaryWriter output, BGEM material)
		{
			base.Serialize(output, material);

			WriteString(output, material.BaseTexture);
			WriteString(output, material.GrayscaleTexture);
			WriteString(output, material.EnvmapTexture);
			WriteString(output, material.NormalTexture);
			WriteString(output, material.EnvmapMaskTexture);

			if (material.Version >= 11)
			{
				WriteString(output, material.SpecularTexture);
				WriteString(output, material.LightingTexture);
				WriteString(output, material.GlowTexture);
			}

			if (material.Version >= 10)
			{
				output.Write(material.EnvironmentMapping);
				output.Write(material.EnvironmentMappingMaskScale);
			}

			output.Write(material.BloodEnabled);
			output.Write(material.EffectLightingEnabled);
			output.Write(material.FalloffEnabled);
			output.Write(material.FalloffColorEnabled);
			output.Write(material.GrayscaleToPaletteAlpha);
			output.Write(material.SoftEnabled);
			WriteColor(output, material.BaseColor);
			output.Write(material.BaseColorScale);
			output.Write(material.FalloffStartAngle);
			output.Write(material.FalloffStopAngle);
			output.Write(material.FalloffStartOpacity);
			output.Write(material.FalloffStopOpacity);
			output.Write(material.LightingInfluence);
			output.Write(material.EnvmapMinLOD);
			output.Write(material.SoftDepth);

			if (material.Version >= 11)
			{
				WriteColor(output, material.EmittanceColor);
			}

			if (material.Version >= 15)
			{
				output.Write(material.AdaptativeEmissive_ExposureOffset);
				output.Write(material.AdaptativeEmissive_FinalExposureMin);
				output.Write(material.AdaptativeEmissive_FinalExposureMax);
			}

			if (material.Version >= 16)
			{
				output.Write(material.Glowmap);
			}

			if (material.Version >= 20)
			{
				output.Write(material.EffectPbrSpecular);
			}
		}
	}
}