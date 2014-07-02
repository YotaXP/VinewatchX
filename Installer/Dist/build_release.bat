set TARGET="C:\Users\Harley\Documents\VinewatchX\Dist"
set SOURCE="C:\Users\Harley\Documents\Visual Studio 2008\Projects\VinewatchX\VinewatchX\VinewatchX\bin\Debug"
set SOURCE2="C:\Users\Harley\Documents\Visual Studio 2008\Projects\VinewatchX\VinewatchX\VinewatchX"

cd %DIST%

copy %SOURCE%\VinewatchX.exe %TARGET%\
copy %SOURCE%\System.Net.Json.dll %TARGET%\
copy %SOURCE%\vinewatchXConfig.txt %TARGET%\

copy %SOURCE2%\changelog.txt %TARGET%\
copy %SOURCE2%\vw.ico %TARGET%\
copy %SOURCE2%\vs.ico %TARGET%\

