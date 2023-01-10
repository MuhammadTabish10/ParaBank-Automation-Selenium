@ECHO OFF
ECHO Automation Executed Started.
set testcategory=OpenNewAccount
set debugPath=C:\Users\muham\source\repos\ParaBank_Automation\ParaBank_Automation\bin\Debug\

call "C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\Tools\VsDevCmd.bat"
VSTest.Console.exe "%debugPath%ParaBank_Automation.dll" /TestCaseFilter:"TestCategory=%testcategory%" /Logger:"trx;LogFileName=C:\Users\muham\source\repos\ParaBank_Automation\ParaBank_Automation\bin\Debug\TestResults\OpenNewAccountTC_001.trx"

cd %debugPath%
TrxToHTML.exe "C:\Users\muham\source\repos\ParaBank_Automation\ParaBank_Automation\bin\Debug\TestResults"

PAUSE