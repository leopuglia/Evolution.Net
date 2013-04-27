@echo off

setlocal

echo.
echo Evolution.Net Project Creation Tool
echo -----------------------------------
echo.

set evolutionInstallPath=L:\_LeoDev\DotNet\_Templates\EvolutionNet.Generation
set basePath=L:\_LeoDev\DotNet

set projectName=
set projectPath=
if "%1" NEQ "" set projectName=%1
if defined projectName goto testProjectExists
if "%projectName%" NEQ "" goto testProjectExists
set /p projectName=Project Name: 

:testProjectExists
set projectPath=%basePath%\%projectName%
if not exist "%projectPath%" goto start
echo ERROR: The project "%projectName%" already exists!
goto end

:start
echo Creating project "%projectName%"
echo.
echo Creating directory "%projectPath%"
md "%projectPath%"
echo Creating directory "%projectPath%"\bin
md "%projectPath%"\bin
echo Creating directory "%projectPath%"\doc
md "%projectPath%"\doc
echo Creating directory "%projectPath%"\lib
md "%projectPath%"\lib
echo Creating directory "%projectPath%"\licenses
md "%projectPath%"\licenses
echo Creating directory "%projectPath%"\resources
md "%projectPath%"\resources
echo Creating directory "%projectPath%"\sql
md "%projectPath%"\sql
echo Creating directory "%projectPath%"\src
md "%projectPath%"\src
echo Creating directory "%projectPath%"\tools
md "%projectPath%"\tools



:success
echo.
echo Projeto criado com sucesso!
echo.

:end
endlocal