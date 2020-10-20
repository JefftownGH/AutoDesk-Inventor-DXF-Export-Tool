# DXF Export Wizard

## Summary
This is a DXF export tool for AutoDesk Inventor, it automates the slow and tedious task of creating DXF files of sheetmetal parts, a process that is required anytime a CAD model is released for manufacture, costing etc.

#### What's a DXF?
 Here's some good general info on the <a href="https://en.wikipedia.org/wiki/AutoCAD_DXF">DXF file format</a> . This application creates a "flat pattern" of Inventor sheetmetal parts and outputs them as a DXF files, this is a useful format for a most costing/manufacturing software.
 
### Prerequisites
This is an plug in for <a href="https://www.autodesk.co.uk/products/inventor/overview?plc=INVPROSA&term=1-YEAR&support=ADVANCED&quantity=1">AutoDesk Inventor</a> This project isn't much use without it...
 
### About
This program is a Standalone .EXE written in C# and uses the Inventor COM (Component Object Model) API. The project currently uses a Windows Forms UI.

### Current Status
Although not a highly polished piece of software it does work well, it was created to meet a need and it was met. Similar software can be purchased from other developers <a href="https://apps.autodesk.com/INVNTOR/en/Home/Index">here</a>.

## Getting Started
#### Importing the Assembly
While an instance of AutoDesk Inventor is running and an Assembly document is open, click the Import button on the user form. The program will recursively search every part in the assembly document and will attempt to create a flat pattern of each sheetmetal component, an import of a printer assembly is shown below, where three sheetmetal components have been identified.

![image](https://github.com/pmccullough060/AutoDesk-Inventor-DXF-Export-Tool/blob/master/DesignValidation/Resources/InitialImport.PNG)

#### Export Settings
Before generating the DXF files its a good idea to check the setting to avoid frustration. The first thing to check is that the "Save In" directory is correct, Next take a look at the DXF Layers options and make sure anything you don't need in the output is deselected. Lastly there is an option to append the material thickness and folded status to the filename of each DXF. Once you're happy click save, your preferences will be retained even once the application has been restarted.

![image](https://github.com/pmccullough060/AutoDesk-Inventor-DXF-Export-Tool/blob/master/DesignValidation/Resources/Settings.PNG)
