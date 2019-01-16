SET projdir="C:\Users\tom\Documents\Projects\Visual Studio\com.edgewords.mandm"
rem make the Test Results folder
MKDIR %projdir%\com.edgewords.mandm\bin\Debug\TestResults
SET testresdir=%projdir%\com.edgewords.mandm\bin\Debug\TestResults
rem run the tests and create the NUnit xml results
cd %projdir%\packages\NUnit.ConsoleRunner.3.9.0\tools
nunit3-console.exe --labels=All --work=%testresdir% --out=%testresdir%\TestResult.txt "--result=TestResult.xml" %projdir%\com.edgewords.mandm\bin\Debug\com.edgewords.mandm.dll --where "cat == functional"
cd %testresdir%
rem use pickles to convert the results to html
%projdir%\packages\Pickles.CommandLine.2.20.1\tools\Pickles.exe --documentation-format=Dhtml --feature-directory=%projdir%\com.edgewords.mandm\Features --link-results-file=.\TestResult.xml --test-results-format=nunit3 --output-directory=.\ --include-experimental-features
rem open them in the default browser
start "" %testresdir%\Index.html
pause

