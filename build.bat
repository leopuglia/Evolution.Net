@echo off
cls

if "%1%"=="/?" (
ECHO **********************************************************************
ECHO * Evolution.Net - http://evolution-net.sourceforge.net
ECHO *
ECHO * To build on framework 2.0, just use
ECHO *   build
ECHO *
ECHO * To build for framework 3.5, use
ECHO *   build 3.5
ECHO *
ECHO * To build debug, use
ECHO *   build debug OR build 3.5 debug
ECHO *
ECHO * To build both debug and release, use
ECHO *   build both OR build 3.5 both
ECHO *
ECHO * The targets in the Evolution.Net.build are:
ECHO *   init    - Initialize all dirs under build and bin
ECHO *   build   - Build all the assemblies on the build dir
ECHO *   all     - Copy the assemblies to the bin dir
ECHO *   zip     - Generate the packed files for publishing
ECHO *   delete  - Delete the build dir
ECHO *   clean   - Delete all files under build and bin dirs
ECHO *   rebuild - Performs clean and all
ECHO *
ECHO **********************************************************************

goto final
)

ECHO **********************************************************************
ECHO * Evolution.Net - http://evolution-net.sourceforge.net
ECHO **********************************************************************

set env=release
set target=2.0
set params=%*
set full=no

if "%1%"=="full" ( 
  set params=%2 %3 %4 %5 %6 
)
if "%1%"=="both" ( 
  set params=%2 %3 %4 %5 %6 
)
if "%1%"=="debug" (
  set params=%2 %3 %4 %5 %6
)
if "%2%"=="both" (
  set params=%3 %4 %5 %6 %7
)
if "%2%"=="debug" (
  set params=%3 %4 %5 %6 %7
)

if "%1%"=="full" goto full
if "%1%"=="3.5" (
  goto 3.5 
) else (
  goto 2.0
)

:start
if "%env%"=="both" (
ECHO ---------------
ECHO BOTH BUILD
)

if "%env%"=="release" goto release

ECHO ---------------
echo DEBUG BUILD
ECHO ---------------
tools\nant\nant.exe -t:net-%target% -l:log.txt -D:debug=true -D:target=%target% -D:deploy=%deploy% -buildfile:evolutionnet.build %params%

if "%env%"=="debug" goto end

:release
ECHO ---------------
ECHO RELEASE BUILD
ECHO ---------------
tools\nant\nant.exe -t:net-%target% -l:log.txt -D:target=%target% -D:deploy=%deploy% -buildfile:evolutionnet.build %params%

if "%full%"=="2.0" goto 3.5

:end

ECHO --------------------
echo BUILD END!!!
ECHO --------------------

goto final



:full
  set full=2.0

:2.0
  set target=2.0
  if "%1%"=="both" (
    set env=both
  )
  if "%1%"=="debug" (
    set env=debug
  )
  if "%2%"=="both" (
    set env=both
  )
  if "%2%"=="debug" (
    set env=both
  )
goto start



:3.5
  set full=3.5

  set target=3.5
  if "%2%"=="both" (
    set env=both
  )
  if "%2%"=="debug" (
    set env=debug
  )
goto start



:final
