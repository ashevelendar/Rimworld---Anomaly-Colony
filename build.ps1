$ErrorActionPreference = 'Stop'

$modRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$sourceRoot = Join-Path $modRoot 'Source\SightstealerColony'
$managedRoot = 'D:\RimWorldNN\RimWorldWin64_Data\Managed'
$compiler = 'C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe'
$outputPath = Join-Path $modRoot '1.6\Assemblies\SightstealerColony.dll'
$assemblyReference = Join-Path $managedRoot 'Assembly-CSharp.dll'
$unityReference = Join-Path $managedRoot 'UnityEngine.CoreModule.dll'
$mathematicsReference = Join-Path $managedRoot 'Unity.Mathematics.dll'
$netstandardReference = 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.11\netstandard.dll'
$systemRuntimeReference = 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\6.0.11\System.Runtime.dll'
$harmonyReference = 'D:\RimWorldNN\Mods\HarmonyMod\Current\Assemblies\0Harmony.dll'
$sourceFiles = Get-ChildItem -LiteralPath $sourceRoot -Filter '*.cs' -File | Select-Object -ExpandProperty FullName

& $compiler /nologo /target:library /optimize+ /platform:x64 /out:$outputPath `
  /reference:$assemblyReference `
  /reference:$unityReference `
  /reference:$mathematicsReference `
  /reference:$netstandardReference `
  /reference:$systemRuntimeReference `
  /reference:$harmonyReference `
  $sourceFiles

if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

Write-Host "Built $outputPath"
