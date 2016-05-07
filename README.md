# cis315_OfficeHours

## LAST SPRINT ASSIGNMENT INFORMATION

All deliverables for the project are contained within this repository folder.
Most relevant items:
-- Reviewed (baseline) requirements documentation:  "\Documentation\requirements\fromReqMngmtTeam"
-- Reviewed design documents or models: Found in "\Diagrams" and "\Models"
-- User stories: Some user stories are within the requirements documentss
-- Test cases: "\test_cases"
-- Burn charts, backlogs, etc: "\Documentation\sftw_process_docs\masterProductBacklog" contains a master feature list, burn charts from                                each sprint, progress notes, and future functionality lists
-- Team charters: "\Documentation\sftw_process_docs\" contains our SDLC document.

## Project Information
Github repo for Spring CIS315 2016 Office Hours project at Gannon University. The repository is also avaiable on
Gannon's CIS GitLab internal site. The project is hosted on an internal, virtual server belonging to Gannon's ITS Department.

Repo: https://github.com/jgrussjr/cis315_OfficeHours

Live website: http://206.180.208.124/welcome.aspx
  You must be on Gannon's internal network.
  
## Synopsis

The Office Hours Scheduling System is an ASP.NET / C# Webapp which allows students at Gannon University to:
-- View professor's office hours, office location, and email
-- Schedule an appointment with the professor during office hours via an ICS email

## Technologies

Technologies Used:
-- ASP.NET Framework 4.5.2
-- Microsoft SQL Server 2012 Express

## Components

The main components of the project are all contained in "code/".
"Office Hours" is the master component of the project. This is the Visual Studio Project that is the 
merged and functional webapp. It is autonomous from the other components which reside in "code/".
The other components are stand-alone subsets of the project, for development sake. 

Comonent List (defined in "code/":
├───CAFE-data-interface : * subcomponent for interfacing with the Cafe system at Gannon. Office Hours and Professor Data
├───code Appointments-data-interface : * subcomponent for interfacing with the appointments database, which we created
├───LoginManager : * subcomponent for managin login
├───OfficeHours : * Main component, integrating the others, to produce the webapp
└───sendApptEmail : * Component which creates an ICS file and sends it via email to student and professor. Also defines interface for                       use by other components. 

## Installation
The project was developed through Visual Studio 2015. The gitignore file and the setup of Visual Studio properties
in the master and sprint 4 branches of the project allow a user to open the .sln of each component, and Visual Studio
with the help NuGet Package Manger should load and configure all dependancies.

The SQL server must be running and have a copy of the CAFE database running. To interface with it, define the database
connection in visual studio. The server should also have the "appointments" database running, as well.

The application must be hosted on a web server with the required technologies. Visual studio will, by default, attempt to host
the application its own version of IIS Express when you press run the project via the web browser button in VS.

## Implementation

The main subcomponents needed for full project functionality are included in the OfficeHours project, but not all
components are fully integrated and interfacing together at the time of the end of development. The webapp currently does
not connect to the login database for login. The appointments database is also currently not integrated. Finally, the sending
of the ICS email from the webapp is not fully connected. Testing and demonstration of the email component can be done cia the email subcomponent. 


