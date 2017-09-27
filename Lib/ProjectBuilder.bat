@ECHO OFF

rem -------------- THAY DOI DUONG DAN DEN SOLUTION TAI DAY ---------------
set SolutionSvnUrl=https://sm-server:5100/svn/2015/Savar/trunk/SM.Savar/
set SolutionFolder=D:\ProjectBuilder\SourceCode\01.FlexValuation\SourceCode
set BuilderFolder=D:\ProjectBuilder\SourceCode\01.FlexValuation\Builder
set WebProjectFolder=SM.Savar
set WebProjectFile=SM.Savar.csproj
set ServiceProjectFolder=SM.Savar.WinService
set ServiceProjectFile=SM.Savar.WinService.csproj
set Configurations=Release

rem 1. Set value for variables
set TempOutput=%CD%\TempOutput
set TimeString=%Time: =0%
set Publish=%CD%\FV_%DATE:~10,4%%DATE:~4,2%%DATE:~7,2%_%TimeString:~0,2%%TimeString:~3,2%
set Builder=%BuilderFolder%\ProjectBuilder.proj
set BuilderDllFilePath=%BuilderFolder%\ProjectBuilder.dll
set WebProjectFilePath= %SolutionFolder%\%WebProjectFolder%\%WebProjectFile%
set ServiceProjectFilePath= %SolutionFolder%\%ServiceProjectFolder%\%ServiceProjectFile%

rem 2. Clean and 
IF EXIST "%TempOutput%"	(
rmdir "%TempOutput%" /s /q
	echo Deleting folder %TempOutput%"
	timeout 2
)
IF EXIST "%TempOutput%" (
	%Windir%\System32\WindowsPowerShell\v1.0\Powershell.exe write-host "Deleted folder failed: %TempOutput%"  -foreground "red"
	GOTO End
)

IF EXIST "%Publish%"	(
rmdir "%Publish%" /s /q
	echo Deleting folder %Publish%"
	timeout 2
)
IF EXIST "%Publish%" (
	%Windir%\System32\WindowsPowerShell\v1.0\Powershell.exe write-host "Deleted folder failed: %Publish%"  -foreground "red"
	GOTO End
)

setlocal ENABLEDELAYEDEXPANSION
@for %%c in (%Configurations%) DO (
	set Configuration=%%c
	set WebFolder=!TempOutput!\!Configuration!\!WebProjectFolder!\_PublishedWebsites\!WebProjectFolder!
	set ServiceFolder=!TempOutput!\!Configuration!\!ServiceProjectFolder!

	%Windir%\System32\WindowsPowerShell\v1.0\Powershell.exe write-host "Start Mode !Configuration!"  -foreground "green"
	
	rem 3. Build
	C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "!Builder!" /property:Configuration=!Configuration!;platform=AnyCPU;SolutionFolder="!SolutionFolder!";MyOutputPath="!TempOutput!";WebProjectFilePath="!WebProjectFilePath!";ServiceProjectFilePath="!ServiceProjectFilePath!";SolutionSvnUrl="!SolutionSvnUrl!";BuilderDllFilePath="!BuilderDllFilePath!" /verbosity:quiet
	if ERRORLEVEL 1 goto :end

	rem 4. Restructure Folders / Files
	del "!ServiceFolder!\*.xml"
	del "!ServiceFolder!\*.exe"
	del "!ServiceFolder!\*.config"
	del "!ServiceFolder!\log4net.dll"

	del "!WebFolder!\*.config"
	del "!WebFolder!\bin\*.xml"
	del "!WebFolder!\bin\log4net.dll"
	rmdir "!WebFolder!\Templates" /q /s

	rem Create Folder structure Move to
	@if !Configuration!==Release (
		set DesFolder=01.LIVE
	) else (
		set DesFolder=02.UAT
	)

	mkdir "!Publish!\!DesFolder!"
	move "!WebFolder!" "!Publish!\!DesFolder!\Web"
	move "!ServiceFolder!" "!Publish!\!DesFolder!\Service"
)

mkdir "%Publish%\03.Database"
mkdir "%Publish%\04.Templates"
echo Release note %DATE:~7,2%/%DATE:~4,2%/%DATE:~10,4% >%Publish%\ReleaseNote.txt

rem Clean
rmdir "%TempOutput%" /s /q

%Windir%\System32\WindowsPowerShell\v1.0\Powershell.exe write-host "Finish all"  -foreground "green"
goto End

:End
pause
