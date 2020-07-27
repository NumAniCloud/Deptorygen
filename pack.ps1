﻿function pack([string]$path) {
    Write-Host "==== ${path} をパッケージ化します" -ForegroundColor Cyan;
    dotnet pack $_ -c Debug -o nupkgs\ --version-suffix $ver --include-source -v minimal;
    sleep 2
}

$paths = "Source/Deptorygen/Deptorygen.csproj",`
    "Source/Deptorygen.Annotations/Deptorygen.Annotations.csproj",`
    "Source/Deptorygen.GenericHost/Deptorygen.GenericHost.csproj"

$ver = cat nupkgs/version
$ver = [System.Int32]::Parse($ver) + 1

rm nupkgs/*.nupkg
$paths | foreach { pack $_ }

echo $ver > nupkgs/version