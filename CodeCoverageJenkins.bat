:: Create a 'GeneratedReports' folder if it does not exist
if not exist "%~dp0GeneratedReports" mkdir "%~dp0GeneratedReports"

::Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0GeneratedReports\GEDigitalCockpitTest.trx" del "%~dp0GeneratedReports\GEDigitalCockpitTest.trx"

:: Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

::Run the tests against the targeted output
call :RunOpenCoverUnitTestMetrics

::Generate the report output based on the test results
if %errorlevel% equ 0 (
call :RunReportGeneratorOutput
)

::Launch the report
if %errorlevel% equ 0 (
call :RunLaunchReport
)
exit /b %errorlevel%

:RunOpenCoverUnitTestMetrics
"C:\BuildConfigs\opencover.4.6.519\OpenCover.Console.exe" ^
-register:user ^
-target:"C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0UnitTest\BusinessAccess\GE.DigitalCockpit.BusinessAccess.Common.Test\bin\Debug\GE.DigitalCockpit.BusinessAccess.Common.Test.dll\" /testcontainer:\"%~dp0UnitTest\DataAccess\GE.DigitalCockpit.DataAccess.FLDC\bin\Debug\GE.DigitalCockpit.DataAccess.FLDC.Test.dll\" /testcontainer:\"%~dp0GE.DigitalCockpit.BusinessAccess.FLDC.Test\bin\Debug\GE.DigitalCockpit.BusinessAccess.FLDC.Test.dll\" /testcontainer:\"%~dp0GE.DigitalCockpit.BusinessAccess.LLDC.Test\bin\Debug\GE.DigitalCockpit.BusinessAccess.LLDC.Test.dll\" /testcontainer:\"%~dp0GE.DigitalCockpit.DataAccess.LLDC.Test\bin\Debug\GE.DigitalCockpit.DataAccess.LLDC.Test.dll\" /resultsfile:\"%~dp0GeneratedReports\GEDigitalCockpitTest.trx\"" ^
-filter:"+[GE.DigitalCockpit*]* -[GE.DigitalCockpit.BusinessAccess.Common.Test]* -[GE.DigitalCockpit.Shared.Entities.FLDC]* -[GE.DigitalCockpit.Shared.Entities.Common]* -[GE.DigitalCockpit.Shared]* -[GE.DigitalCockpit.DataAccess.Common]* -[GE.DigitalCockpit.DataAccess.FLDC.Test]* -[GE.DigitalCockpit.BusinessAccess.FLDC.Test]* -[GE.DigitalCockpit.Shared.Entities.LLDC]* -[GE.DigitalCockpit.DataAccess.LLDC.Test]* -[GE.DigitalCockpit.BusinessAccess.LLDC.Test]*"^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0GeneratedReports\GEDigitalCockpitTest.xml"
exit /b %errorlevel%

:RunReportGeneratorOutput
"%~dp0packages\ReportGenerator.2.5.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0GeneratedReports\GEDigitalCockpitTest.xml" ^
-targetdir:"%~dp0GeneratedReports\ReportGenerator Output"
exit /b %errorlevel%

:RunLaunchReport
start "report" "%~dp0GeneratedReports\ReportGenerator Output\index.htm"
exit /b %errorlevel%
