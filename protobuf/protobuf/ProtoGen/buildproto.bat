@echo off
if exist "%~dp0/protocs" rmdir /s /q "%~dp0/protocs"
mkdir "%~dp0/protocs"

cd %~dp0/proto
for %%i in (*.proto) do (
	echo %%i
	..\protogen.exe -i:%%i -o:../protocs/%%i
	
)
cd ../protocs/
rename *.proto *.cs

for %%i in (*.cs) do (
	move %%i ../../../../Wolley_Client/Assets/Scripts/Network/Message/
)

pause