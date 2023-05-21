using ConvertMaterial.Models;

namespace ConvertMaterial.Binary
{
	public class BGEMDeserializer : BaseDeserializer
	{
		public BGEM Deserialize(BinaryReader input)
		{
			var material = new BGEM();
			base.Deserialize(input, material);

			material.BaseTexture = ReadString(input);
			material.GrayscaleTexture = ReadString(input);
			material.EnvmapTexture = ReadString(input);
			material.NormalTexture = ReadString(input);
			material.EnvmapMaskTexture = ReadString(input);

			if (material.Version >= 11)
			{
				material.SpecularTexture = ReadString(input);
				material.LightingTexture = ReadString(input);
				material.GlowTexture = ReadString(input);
			}

			if (material.Version >= 10)
			{
				material.EnvironmentMapping = input.ReadBoolean();
				material.EnvironmentMappingMaskScale = input.ReadSingle();
			}

			material.BloodEnabled = input.ReadBoolean();
			material.EffectLightingEnabled = input.ReadBoolean();
			material.FalloffEnabled = input.ReadBoolean();
			material.FalloffColorEnabled = input.ReadBoolean();
			material.GrayscaleToPaletteAlpha = input.ReadBoolean();
			material.SoftEnabled = input.ReadBoolean();

			material.BaseColor = ReadColor(input);
			material.BaseColorScale = input.ReadSingle();

			material.FalloffStartAngle = input.ReadSingle();
			material.FalloffStopAngle = input.ReadSingle();
			material.FalloffStartOpacity = input.ReadSingle();
			material.FalloffStopOpacity = input.ReadSingle();

			material.LightingInfluence = input.ReadSingle();
			material.EnvmapMinLOD = input.ReadByte();
			material.SoftDepth = input.ReadSingle();

			if (material.Version >= 11)
			{
				material.EmittanceColor = ReadColor(input);
			}

			if (material.Version >= 15)
			{
				material.AdaptativeEmissive_ExposureOffset = input.ReadSingle();
				material.AdaptativeEmissive_FinalExposureMin = input.ReadSingle();
				material.AdaptativeEmissive_FinalExposureMax = input.ReadSingle();
			}

			if (material.Version >= 16)
			{
				material.Glowmap = input.ReadBoolean();
			}

			if (material.Version >= 20)
			{
				material.EffectPbrSpecular = input.ReadBoolean();
			}

			return material;
		}
	}
}