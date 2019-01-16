nunit3-console.exe my.test.dll --result=my.test.summary.txt;transform=text-summary.xslt --result=TestResult.xml

SET projdir="C:\Users\tom\Documents\Projects\Visual Studio\com.edgewords.mandm"
rem make the Test Results folder
MKDIR %projdir%\com.edgewords.mandm\bin\Debug\TestResults
SET testresdir=%projdir%\com.edgewords.mandm\bin\Debug\TestResults
rem run the tests and create the NUnit xml results
cd %projdir%\packages\NUnit.ConsoleRunner.3.9.0\tools
nunit3-console.exe --work=%testresdir% --result=summary.html;transform=%projdir%\com.edgewords.mandm\Reporting\FullReport.xslt --result=TestResult.xml %projdir%\com.edgewords.mandm\bin\Debug\com.edgewords.mandm.dll --where "cat == functional"
cd %testresdir%
rem open them in the default browser
start "" %testresdir%\summary.html
pause