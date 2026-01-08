@echo off
title SulfoxidoOS v5.0 - Terminal Kernel
mode con: cols=80 lines=25

:BOOT
color 05
echo.
echo  [ SULFOXIDO KERNEL ]
echo  Carregando modulos de enxofre...
timeout /t 1 >nul
echo  Montando HelioFS virtual...
timeout /t 1 >nul
echo  Iniciando Prompt Interface...
timeout /t 1 >nul
goto LOGIN

:LOGIN
cls
echo.
echo  ==================================================
echo             S U L F O X I D O   O S
echo  ==================================================
echo.
echo  SENHA REQUERIDA: (Dica: sulfox123)
set /p "pass=>> "
if "%pass%"=="sulfox123" (goto DESKTOP) else (echo Senha Incorreta! & pause & goto LOGIN)

:DESKTOP
cls
color 0D
echo  ==========================================================================
echo   SULFOXIDO OS v5.0  ^|  %date%  ^|  %time%  ^|  ADMIN
echo  ==========================================================================
echo.
echo     [1] NOTAS         [2] ARQUIVOS      [3] CALCULADORA
echo    +-----------+     +-----------+     +-----------+
echo    ^|   .....   ^|     ^|   /---/   ^|     ^|   [789]   ^|
echo    ^|   .....   ^|     ^|   [DIR]   ^|     ^|   [456]   ^|
echo    +-----------+     +-----------+     +-----------+
echo.
echo     [4] RELOGIO       [5] TERMINAL      [6] SAIR
echo    +-----------+     +-----------+     +-----------+
echo    ^|    / \    ^|     ^|   S:\^>_   ^|     ^|   [OFF]   ^|
echo    ^|    ---    ^|     ^|   _____   ^|     ^|   _____   ^|
echo    +-----------+     +-----------+     +-----------+
echo.
echo  ==========================================================================
echo   LOG: Sistema pronto. Aguardando comando quimico...
echo  ==========================================================================
set /p "choice=Sulfoxido >> "

if "%choice%"=="1" start notepad.exe
if "%choice%"=="2" start explorer.exe .
if "%choice%"=="3" start calc.exe
if "%choice%"=="4" goto CLOCK
if "%choice%"=="5" goto SHELL
if "%choice%"=="6" exit
goto DESKTOP

:CLOCK
cls
color 0D
echo.
echo  --- RELOGIO SULFOXIDO ---
echo.
echo  DATA: %date%
echo  HORA: %time%
echo.
echo  Pressione qualquer tecla para voltar...
pause >nul
goto DESKTOP

:SHELL
cls
color 05
echo  SULFOXIDO EMERGENCY SHELL [Versao 5.0]
echo  Digite 'EXIT' para retornar ao modo grafico.
echo.
cmd /k "prompt Sulfoxido-Shell$G"
goto DESKTOP