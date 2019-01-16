SET projdir="C:\Users\tom\Documents\Projects\Visual Studio\com.edgewords.mandm"
rem make the Test Results folder
MKDIR %projdir%\com.edgewords.mandm\bin\Debug\TestResults
SET testresdir=%projdir%\com.edgewords.mandm\bin\Debug\TestResults
rem run the tests and create the NUnit xml results
cd %projdir%\packages\NUnit.ConsoleRunner.3.9.0\tools
nunit3-console.exe --labels=All --work=%testresdir% --out=%testresdir%\TestResult.txt "--result=TestResult.xml;format=nunit2" %projdir%\com.edgewords.mandm\bin\Debug\com.edgewords.mandm.dll --where "cat == functional"
cd %testresdir%
rem use the specflow tool to convert the results to html
rem %projdir%\packages\SpecFlow.2.4.1\tools\specflow.exe nunitexecutionreport --XsltFile %projdir%\ExecutionReport.xslt --ProjectFile %projdir%\com.edgewords.mandm\com.edgewords.mandm.csproj
%projdir%\packages\SpecFlow.2.4.1\tools\specflow.exe nunitexecutionreport --ProjectFile %projdir%\com.edgewords.mandm\com.edgewords.mandm.csproj
rem open them in the default browser
start "" %testresdir%\TestResult.html
pause
