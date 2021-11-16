@echo off
del /f /s /q ..\..\resources\acinstall\*.exe
del /f /s /q ..\..\resources\acinstall\*.dll
copy ..\ac.exe ..\..\resources\acinstall\
copy ..\*.dll ..\..\resources\acinstall\
copy ..\tools\*.exe ..\..\resources\acinstall\tools\
copy ..\config\*.acfg ..\..\resources\acinstall\config\
exit
