@echo off

cd /d %~dp0

@echo *******************���Թ���Ա������д˽ű�***************************

@echo ���ڰ�װ...(sc��ʽҪ��,=��ǰ�����пո�,����Ҫ�пո�)

sc create WebGetData.WindowsService binPath= "%CD%\WebGetData.WindowsService.exe" displayname= "WebGetData.WindowsService" start= "auto"

sc description WebGetData.WindowsService "�����Զ��������ݽӿ�,����˷��񱻽��ã����޷��������ݡ�" 

@echo ��װ���!  start= "auto"
@echo ����װλ��: "%CD%\WebGetData.WindowsService.exe"
@echo �������´�����ϵͳ���Զ�����
@echo   ���� 
@echo ʹ������:  net start WebGetData.WindowsService    �ֹ���������
@echo ʹ������:  sc delete WebGetData.WindowsService ж�ط���
@echo .
@echo .
@pause