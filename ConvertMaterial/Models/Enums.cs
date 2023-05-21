namespace ConvertMaterial.Models
{
	[Flags]
	public enum MaskWriteFlags
	{
		Albedo = 1,
		Normal = 2,
		Specular = 4,
		AmbientOcclusion = 8,
		Emissive = 16,
		Gloss = 32
	}

	public enum AlphaBlendModeType
	{
		Unknown = 0,
		None,
		Standard,
		Additive,
		Multiplicative,
	}

	public enum MaterialType : uint
	{
		None = 0,
		BGEM = 0x4D454742u,
		BGSM = 0x4D534742u
	}
}