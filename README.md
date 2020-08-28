# DXF Export Wizard
This project is a DXF export tool for AutoDesk Inventor, it automates the slow and tedious process of creating DXF files of sheetmetal parts, a process that is required anytime a CAD model is released for manufacture.

This program is a Standalone .EXE written in C# and uses the Inventor COM (Component Object Model) API. The project currently uses a Windows Forms UI.

How it works?
While an instance of AutoDesk Inventor is running and an Assembly document is open, click the Import button on the user form. The program will recursively search every part in the assembly document and will attempt to create a flat pattern of each sheetmetal component. The DXF file can also be customised, DXF Export Wizard gives access to each layer item and allows the user to select a solid line, no line or a dashed line, something that is not natively supported in AutoDesk Inventor. 
