using ConvertMaterial.Models;

namespace ConvertMaterial.Binary
{
	public abstract class BaseDeserializer
	{
		protected string ReadString(BinaryReader input)
		{
			var length = input.ReadUInt32();
			string str = new string(input.ReadChars((int)length));
			int index = str.LastIndexOf('\0');
			if (index >= 0) str = str.Remove(index, 1);
			return str;
		}

		protected Color ReadColor(BinaryReader input)
		{
			var r = input.ReadSingle();
			var g = input.ReadSingle();
			var b = input.ReadSingle();
			return new Color(r, g, b);
		}

		protected AlphaBlendModeType ReadAlphaBlendMode(BinaryReader input)
		{
			var a = input.ReadByte();
			var b = input.ReadUInt32();
			var c = input.ReadUInt32();

			return (a, b, c) switch
			{
				{ a: 0, b: 6, c: 7 } => AlphaBlendModeType.Unknown,
				{ a: 0, b: 0, c: 0 } => AlphaBlendModeType.None,
				{ a: 1, b: 6, c: 7 } => AlphaBlendModeType.Standard,
				{ a: 1, b: 6, c: 0 } => AlphaBlendModeType.Additive,
				{ a: 1, b: 4, c: 1 } => AlphaBlendModeType.Multiplicative,
				_ => throw new NotSupportedException()
			};
		}

		protected void Deserialize(BinaryReader input, Material material)
		{
			material.Version = input.ReadUInt32();

			var tileFlags = input.ReadUInt32();
			material.TileU = (tileFlags & 2) != 0;
			material.TileV = (tileFlags & 1) != 0;

			material.UOffset = input.ReadSingle();
			material.VOffset = input.ReadSingle();
			material.UScale = input.ReadSingle();
			material.VScale = input.ReadSingle();
			material.Alpha = input.ReadSingle();
			material.AlphaBlendMode = ReadAlphaBlendMode(input);
			material.AlphaTestRef = input.ReadByte();
			material.AlphaTest = input.ReadBoolean();
			material.ZBufferWrite = input.ReadBoolean();
			material.ZBufferTest = input.ReadBoolean();
			material.ScreenSpaceReflections = input.ReadBoolean();
			material.WetnessControlScreenSpaceReflections = input.ReadBoolean();
			material.Decal = input.ReadBoolean();
			material.TwoSided = input.ReadBoolean();
			material.DecalNoFade = input.ReadBoolean();
			material.NonOccluder = input.ReadBoolean();
			material.Refraction = input.ReadBoolean();
			material.RefractionFalloff = input.ReadBoolean();
			material.RefractionPower = input.ReadSingle();

			if (material.Version < 10)
			{
				material.EnvironmentMapping = input.ReadBoolean();
				material.EnvironmentMappingMaskScale = input.ReadSingle();
			}
			else
			{
				material.DepthBias = input.ReadBoolean();
			}

			material.GrayscaleToPaletteColor = input.ReadBoolean();

			if (material.Version >= 6)
			{
				material.MaskWrites = (MaskWriteFlags)input.ReadByte();
			}
		}
	}
}