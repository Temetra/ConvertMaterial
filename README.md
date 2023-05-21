# ConvertMaterial

A command line tool for Fallout 4/76. It converts BGSM/BGEM material files to and from JSON.

## Requirements

[.NET Desktop Runtime 7.0.5](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

## Usage

```
ConvertMaterial.exe <input> [<output>]
```

## Examples

```powershell
# This will save 'data\material.bgsm' as 'data\material.json'.
ConvertMaterial.exe data\material.bgsm
```

```powershell
# Specify the output path to save elsewhere.
ConvertMaterial.exe project\source.json data\material.bgsm
```

## Credits

The majority of this code was written by [ousnius](https://github.com/ousnius/Material-Editor/), [gibbed](https://github.com/gibbed) and [jonwd7](https://github.com/jonwd7).

I've taken the material serialization classes, refactored them, and wrapped the whole thing with a command line executable.