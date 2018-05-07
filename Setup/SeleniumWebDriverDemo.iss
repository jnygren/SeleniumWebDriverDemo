; SeleniumWebDriverDemo Setup.iss

; (See 'Help - Inno Setup Documentation' for Script format.)

;     Constants
; {src} - The directory in which the Setup files are located
; {app} - Application destination location. (e.g. 'C:\Program Files\progName')
; {pf} - Program Files directory.
; {group} - The path to the Start Menu folder

; Setup section
; SourceDir - Location of source (.exe, Readme) files. (relative to .iss location.)
; OutputBaseFilename - Name of setup (.exe) file.
[Setup]
AppName=SeleniumWebDriverDemo
AppVersion=1.2.1
DefaultDirName={pf}\SeleniumWebDriverDemo
DefaultGroupName=SeleniumWebDriverDemo
SourceDir="..\SeleniumWebDriverDemo\bin\Release"
; If you set 'SourceDir', you must force 'OutputDir' to be where you want it.
OutputDir="..\..\..\Setup\Output"
OutputBaseFilename="SeleniumWebDriverDemo_Setup"

; [Types]  Type of installation. (e.g. "full", "custom", etc.)

; Files section (i.e. the .exe file)
[Files]
Source: "SeleniumWebDriverDemo.exe"; DestDir: "{app}"
Source: "SeleniumWebDriverDemo.exe.config"; DestDir: "{app}"
Source: "NLog.config"; DestDir: "{app}"
Source: "NLog.dll"; DestDir: "{app}"
Source: "WebDriver.dll"; DestDir: "{app}"
Source: "geckodriver.exe"; DestDir: "{app}"
Source: "chromedriver.exe"; DestDir: "{app}"

; Icons section - Defines shortcuts to be created.
[Icons]
; (NO shortcuts are created by default. You need this.)
; 'Comment:' parameter is tooltip for icon.
; ({userdesktop} doesn't work!)
;Name: "{userdesktop}\SeleniumWebDriverDemo"; Filename: "{app}\SeleniumWebDriverDemo.exe"; Tasks: "desktopicon"; Comment: "Comment Comment Comment."
Name: "{commondesktop}\SeleniumWebDriverDemo"; Filename: "{app}\SeleniumWebDriverDemo.exe"; Tasks: "desktopicon"; Comment: "Demonstrate use of Selenium WebDriver."
Name: "{group}\SeleniumWebDriverDemo"; Filename: "{app}\SeleniumWebDriverDemo.exe"; Comment: "Demonstrate use of Selenium WebDriver."
Name: "{group}\Uninstall SeleniumWebDriverDemo"; Filename: "{uninstallexe}"

; Tasks section - Defines user-customizable tasks
[Tasks]
Name: "desktopicon"; Description: "Create a desktop icon"

; Run section
[Run]
Filename: "notepad.exe"; Parameters: "{app}\SeleniumWebDriverDemo.exe.config"; Flags: shellexec postinstall; Description: "Edit configuration file."
Filename: "notepad.exe"; Parameters: "{app}\NLog.config"; Flags: shellexec postinstall; Description: "Set logging level."

; End of Script