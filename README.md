# Functional Checks and Automation Criteria
Discussed in detail in document named **_'Functional Tests and Automation Criteria_'** within this repository

# Project Overview
* Automated UI Tests for some features of Xeneta's Website using .Net Core, Selenium, Specflow and Nunit
* Runs with current chrome version: 89.0.4389.114 
* Selenium.WebDriver.ChromeDriver package can be updated for future chrome verisons via Nuget Manager in Visual Studio 2019
* Target framework version for the project is .Net Core 2.1

# Project Structure/Flow
1. The tests are defined using Gherkin Syntax in *Feature* files (extenseion: .features) located in *Features* folder
2. Feature files contain *Scnarios* which are basically the tests
3. The Scenarios have steps in Gherkin Syntax (Give, When, Then etc)
4. The scenario steps map to corresponding *Step Definition* files located in *Steps* folder
5. Pressing F12 on a scenario step will open its step definition method
6. The step definition methods call functions in repective *Page Object* classes
7. Page Object classes in the *Pages* folder use selenium to locate elements, perform actions and return properties
8. Browser initialization and disposal is done in *WebDriverHooks.cs* in *Hooks* folder

# Open and Run Project
## Visual Studio 2019 on Windows or Mac
1. If you already have Visual Studio 2019 skip to step 3
2. If you don't have Visual Studio 2019:
    * For Windows: You can download and use the 2019 Community Edition for free
      * During installation select '.NET Core cross-platform development' in 'Workloads' tab
    * For Mac: You can download and use Visual Studio 2019 Mac for free
      * During installation select '.Net Core' in 'What would you like to install' screen
3. Open Visual Studio and Install SpecFlow extension:
    * For Windows: Go to Extensions -> Manage Extensions and search *'SpecFlow'* in Online Extensions and install
    * For Mac: Go to Visual Studio -> Extensions -> Gallery and search *'Straight8's SpecFlow Integration'* and install
4. Restart Visual Studio and open *'XenetaWebApp.Tests.sln'* file
5. Build the solution:
    * For Windows: Ctrl + Shift + B
    * For Mac: Cmd + B
6. Use Solution Explorer to view the project files
7. The tests are structured as:
    * Feature Files contain Scenarios(tests) -> Scenarios contain Steps -> Steps map to Step Definition methods -> Step Definition methods use Page Object classes
8. Use Test Explorer to view, run and debug the tests
9. You can start a test run as:
    * Run all tests of all Features
    * Run all tests of a particular Feature
    * Run a particular test of a particular Feature

## Visual Studio Code on Windows or Mac
#### Visual Studio 2019 offers better Project Files View and SpecFlow Integration
1. Open visual Studio Code and install following extensions:
    * C# by Microsoft
    * vscode-solution-explorer
    * Specflow Tools
    * .Net Core Test Explorer by Derivitec Ltd
2. Restart Visual Studio Code if Prompted
3. Click File then click Open and select Solution folder named *'XenetaWebApp.Tests'*
4. Build the solution:
    * For Windows: Ctrl + Shift + B
    * For Mac: Cmd + B
5. Use Solution Explorer to view the project files
6. The tests are structured as:
    * Feature Files contain Scenarios(tests) -> Scenarios contain Steps -> Steps map to Step Definition methods -> Step Definition methods use Page Object classes
7. Use Test Explorer on left menu to view all features and their tests
8. You can start a test run by:
    * Running all tests of all Features
    * Running all tests of a particular Feature
    * Running a particular test of a particular Feature
