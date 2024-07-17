set UNITY_PATH=D:\Programs\Unity\Hub\Editor\2022.3.13f1\Editor\Unity.exe
set PROJECT_PATH=%cd%

%UNITY_PATH% -quit -batchmode -executeMethod Builder.Build -projectPath %PROJECT_PATH% -logFile>mylog.txt

pause
