@echo off

cd /d %~dp0

echo *******************���Թ���Ա������д˽ű�***************************

net stop WebGetData.WindowsService

mkdir ..\RtmV1

ECHO ��ǰĿ¼��%CD%

del /Q ..\Debug\log
del /Q ..\RtmV1\log

XCOPY ..\Debug\WebGetData.WindowsService* ..\RtmV1\ /e /y

cd ..\RtmV1

net start WebGetData.WindowsService

@pause