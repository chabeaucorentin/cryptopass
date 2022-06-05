#define MyAppName "CryptoPass"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Xaphyr Software"
#define MyAppURL "https://www.xaphyr.com/"
#define MyAppExeName "Views.exe"
#define MyAppPath "..\Views\bin\Release\net6.0-windows\publish"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{02A3D671-948A-49DE-B200-1158883529F1}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableDirPage=yes
DisableProgramGroupPage=yes
LicenseFile=license.txt
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
OutputDir=.\
OutputBaseFilename=cryptopass-setup
SetupIconFile=icon.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "french"; MessagesFile: "compiler:Languages\French.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#MyAppPath}\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Models.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Models.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Newtonsoft.Json.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\ViewModels.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\ViewModels.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Views.deps.json"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Views.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Views.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#MyAppPath}\Views.runtimeconfig.json"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

[Registry]
Root: HKCU; Subkey: "Software\{#MyAppName}"; Flags: uninsdeletekey
