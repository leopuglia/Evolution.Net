@echo off
cls

if "%1%" == "debug" (

ECHO ---------------
echo DEBUG BUILD
ECHO ---------------
tools\nant\nant.exe -t:net-2.0 -l:log.txt -D:debug=true -buildfile:evolutionnet_2.0.build %2 %3 %4 %5 %6

) else if NOT "%1%" == "both" (

ECHO ---------------
ECHO RELEASE BUILD
ECHO ---------------
tools\nant\nant.exe -t:net-2.0 -l:log.txt -buildfile:evolutionnet_2.0.build %*

) else (

ECHO ---------------
ECHO BOTH BUILD
ECHO ---------------
echo DEBUG BUILD
ECHO ---------------
tools\nant\nant.exe -t:net-2.0 -l:log.txt -D:debug=true -buildfile:evolutionnet_2.0.build %2 %3 %4 %5 %6

ECHO ---------------
ECHO RELEASE BUILD
ECHO ---------------
tools\nant\nant.exe -t:net-2.0 -l:log.txt -buildfile:evolutionnet_2.0.build %2 %3 %4 %5 %6

)

ECHO --------------------
echo THE END!!!
ECHO --------------------
@ECHO ON
