@echo off
@echo *******************请以管理员身份运行此脚本***************************

net stop AnXinWH.SocketRFIDService

sc delete AnXinWH.SocketRFIDService

@pause
