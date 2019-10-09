# My Journal

My Journal is a website designed for daily journaling online along with statistics about your journaling and your day

## Requirments
- IDE
    - Visual Studio 2017
    - Visual Studio 2019
    - Must pick to add ASP.net tools while installing Visual Studio
- .Net Core 2 SDK

## How To Run
- Open MyJournal.sln with Visual Studio
- Right click the project (top MyJournal folder) in the solution explorer
    - click 'manage user secrets'
    - copy and paste from the file 'program/userSecrets'
    - save and close the file
- Open the 'Package Managment Console' (Tool -> Nuget Package Manager -> Package Managment Console)
    - Run the command 'add-migration initial'
    - Run the command 'update-database'
- Click the green play button that says 'IIS Express' to run
    
