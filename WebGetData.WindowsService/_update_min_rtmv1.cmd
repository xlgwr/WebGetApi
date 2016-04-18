@echo off

cd /d %~dp0

echo *******************请以管理员身份运行此脚本***************************

net stop WebGetData.WindowsService

mkdir ..\RtmV1

ECHO 当前目录：%CD%

del /Q ..\Debug\log
del /Q ..\RtmV1\log

XCOPY ..\Debug\WebGetData.WindowsService* ..\RtmV1\ /e /y

cd ..\RtmV1

net start WebGetData.WindowsService

@pause