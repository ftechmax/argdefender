param(
    [switch]$NoInstall=$false,
    [ValidateSet("Debug","Release","CI")][string]$Configuration="Release",
    [ValidateSet("netstandard1.0","netstandard2.0")][string]$Framework="netstandard2.0"
)

IF ($NoInstall -eq $false)
{
    & $PSScriptRoot/install-dotnet.ps1
}

$SdkPath = "$PSScriptRoot/../artifacts/dotnet/dotnet"
IF ($IsWindows -or $env:OS -like "Windows*")
{
    $SdkPath += ".exe"
}

IF (-not (Test-Path $SdkPath))
{
    $SdkPath = "dotnet"
}

& $SdkPath restore $PSScriptRoot/../src --verbosity m
& $SdkPath build $PSScriptRoot/../src -c $Configuration -o ../artifacts/build/$Framework/ -f $Framework

exit $lastexitcode
