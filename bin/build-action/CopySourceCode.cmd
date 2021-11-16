@echo off
del /f /s /q ..\..\..\AdminCon-Source\.vs
del /f /s /q ..\..\..\AdminCon-Source\bin
del /f /s /q ..\..\..\AdminCon-Source\Components
del /f /s /q ..\..\..\AdminCon-Source\Modules
del /f /s /q ..\..\..\AdminCon-Source\obj
del /f /s /q ..\..\..\AdminCon-Source\properties
del /f /s /q ..\..\..\AdminCon-Source\*.config
del /f /s /q ..\..\..\AdminCon-Source\*.cs
del /f /s /q ..\..\..\AdminCon-Source\*.csproj
del /f /s /q ..\..\..\AdminCon-Source\*.sln

xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.csproj ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.sln ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.cs ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.resx ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.config ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.manifest ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.cpp ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.c ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.hpp ..\..\..\AdminCon-Source /y
xcopy /f /s ..\..\..\AdminCon_CLI_dotnetEdition\*.h ..\..\..\AdminCon-Source /y
exit






