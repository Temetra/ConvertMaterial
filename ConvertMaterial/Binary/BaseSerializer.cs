using ConvertMaterial.Models;

namespace ConvertMaterial.Binary
{
	public abstract class BaseSerializer
	{
		protected void WriteString(BinaryWriter output, string str)
		{
			if (str == null) return;
			output.Write(str.Length + 1);
			output.Write((str + "\0").ToCharArray());
		}

		protected void WriteColor(BinaryWriter output, Color color)
		{
			output.Write(color.R);
			output.Write(color.G);
			output.Write(color.B);
		}

		protected void WriteAlphaBlendMode(BinaryWriter output, AlphaBlendModeType type)
		{
			byte a;
			uint b;
			uint c;

			if (type == AlphaBlendModeType.Unknown) { a = 0; b = 6; c = 7; }
			else if (type == AlphaBlendModeType.None) { a = 0; b = 0; c = 0; }
			else if (type == AlphaBlendModeType.Standard) { a = 1; b = 6; c = 7; }
			else if (type == AlphaBlendModeType.Additive) { a = 1; b = 6; c = 0; }
			else if (type == AlphaBlendModeType.Multiplicative) { a = 1; b = 4; c = 1; }
			else throw new NotSupportedException();

			output.Write(a);
			output.Write(b);
			output.Write(c);
		}

		protected void Serialize(BinaryWriter output, Material material)
		{
			output.Write((uint)material.MaterialType);
			output.Write(material.Version);

			uint tileFlags = 0;
			if (material.TileU) tileFlags += 2;
			if (material.TileV) tileFlags += 1;
			output.Write(tileFlags);

			output.Write(material.UOffset);
			output.Write(material.VOffset);
			output.Write(material.UScale);
			output.Write(material.VScale);
			output.Write(material.Alpha);
			WriteAlphaBlendMode(output, material.AlphaBlendMode);
			output.Write(material.AlphaTestRef);
			output.Write(material.AlphaTest);
			output.Write(material.ZBufferWrite);
			output.Write(material.ZBufferTest);
			output.Write(material.ScreenSpaceReflections);
			output.Write(material.WetnessControlScreenSpaceReflections);
			output.Write(material.Decal);
			output.Write(material.TwoSided);
			output.Write(material.DecalNoFade);
			output.Write(material.NonOccluder);
			output.Write(material.Refraction);
			output.Write(material.RefractionFalloff);
			output.Write(material.RefractionPower);

			if (material.Version < 10)
			{
				output.Write(material.EnvironmentMapping);
				output.Write(material.EnvironmentMappingMaskScale);
			}
			else
			{
				output.Write(material.DepthBias);
			}

			output.Write(material.GrayscaleToPaletteColor);

			if (material.Version >= 6)
			{
				output.Write((byte)material.MaskWrites);
			}
		}
	}
}