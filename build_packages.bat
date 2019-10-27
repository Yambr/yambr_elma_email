@echo off
set baseVersion=3.13.0
echo base %baseVersion%

set /p Build=<version.txt

echo old version %Build%

set /A Build=%Build%+1

echo new version %Build%

break>version.txt

echo %Build% >> version.txt

SET fullVersion=%baseVersion%.%Build% 

echo full %fullVersion%

"C:\ELMA3-Enterprise\PackageManager\EleWise.ELMA.Packaging.Console.exe" packSln %~dp0Yambr.ELMA.Email.sln -v %fullVersion%  -out "C:\ELMA3-Enterprise\Packages" -NoSelfUpdate

