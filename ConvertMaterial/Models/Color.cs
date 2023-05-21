using System.Globalization;

namespace ConvertMaterial.Models
{
	public record struct Color(float R, float G, float B)
	{
		public uint ToUInt32()
		{
			uint value = 0;
			value |= (byte)(R * 255);
			value <<= 8;
			value |= (byte)(G * 255);
			value <<= 8;
			value |= (byte)(B * 255);
			return value;
		}

		public string ToHexString()
		{
			return string.Format("#{0:x6}", ToUInt32() & 0xFFFFFFu);
		}

		public static Color FromUInt32(uint value)
		{
			const float multiplier = 1.0f / 255;
			var b = (byte)(value & 0xFF);
			value >>= 8;
			var g = (byte)(value & 0xFF);
			value >>= 8;
			var r = (byte)(value & 0xFF);
			return new Color(r * multiplier, g * multiplier, b * multiplier);
		}

		public static Color FromHexString(string str)
		{
			var text = str.ToLowerInvariant();

			if (text.StartsWith("#") == true) text = text.Substring(1);
			if (text == "000") return FromUInt32(0x000000u);
			if (text == "fff") return FromUInt32(0xFFFFFFu);

			if (text.Length == 3)
			{
				uint val = uint.Parse(text, NumberStyles.AllowHexSpecifier);
				val = ((val & 0xF00) << 8) | ((val & 0x0F0) << 4) | ((val & 0x00F) << 0);
				val |= val << 4;
				return FromUInt32(val);
			}

			if (text.Length == 6) return FromUInt32(uint.Parse(text, NumberStyles.AllowHexSpecifier));

			return new Color(1.0f, 1.0f, 1.0f);
		}
	}
}