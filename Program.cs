using System.Reflection;
using ConvertMaterial;
using ConvertMaterial.Json;

var input = args.Length > 0 ? args[0] : null;
var output = args.Length > 1 ? args[1] : null;

if (!string.IsNullOrEmpty(input))
{
	try
	{
		var isJson = JsonHelper.FileIsJson(input);
		if (isJson) Transform.FromJsonToBinary(input, output);
		else Transform.FromBinaryToJson(input, output);
	}
	catch (System.IO.FileNotFoundException ex)
	{
		Console.WriteLine(ex.Message);
		Environment.ExitCode = -1;
	}
	catch (System.FormatException)
	{
		var fullpath = Path.GetFullPath(args[0]);
		Console.WriteLine($"'{fullpath}' was in an invalid format.");
		Environment.ExitCode = -1;
	}
}
else
{
	var attribute = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>();
	var value = attribute?.InformationalVersion?.Replace("+build", " ");
	Console.WriteLine($"ConvertMaterial {value}");
	Console.WriteLine("");
	Console.WriteLine("Converts from BGEM/BGSM to JSON, and back again.");
	Console.WriteLine("");
	Console.WriteLine("Usage:");
	Console.WriteLine("   ConvertMaterial.exe <input> [<output>]");
	Console.WriteLine("");
	Console.WriteLine("Examples:");
	Console.WriteLine("   ConvertMaterial.exe data\\material.bgsm");
	Console.WriteLine("   ConvertMaterial.exe project\\source.json data\\material.bgsm");
	Console.WriteLine("");
	Environment.ExitCode = -1;
}
