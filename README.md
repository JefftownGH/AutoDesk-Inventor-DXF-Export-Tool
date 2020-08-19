# DXF Export Wizard
This project is a DXF export tool for AutoDesk Inventor, it automates the slow and tedious process of creating DXF files of sheetmetal part files, a process that is required anytime a CAD design is released for manufacture.

This program is a Standalone .EXE written in C# and uses the Inventor COM (Component Object Model) API. The project currently uses a Windows Forms based UI.

How it works?
While an instance of AutoDesk Inventor is running and an Assembly document is open, click the Import button on the user form. The program will recursively search every item in the assembly document 
