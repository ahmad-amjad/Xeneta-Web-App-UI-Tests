# Xeneta-Web-App-UI-Tests
1. Automated UI Tests for some features of Xeneta's Website using .Net Core, Selenium, Specflow and Nunit
2. Runs with current chrome version: 89.0.4389.114 
3. Selenium.WebDriver.ChromeDriver package can be updated for future verisons via Nuget Manager in Visual Studio 2019

# Running tests using Visual Studio 2019
1. Open XenetaWebApp.Tests.sln file from visual studio
2. Press Control + Shift + B to build the solution
3. To see tests structure go to Solution Explorer
4. The tests are defined in feature files
5. Feature files map to corresponding step definitions that call test functions in repective page classes
6. Page classes use selenium to locate elements, perform actions and return properties
7. Open Test Explorer to view all features and their tests
8. You can run all tests or a features tests or a single test

# Running tests using Visual Studio Code
1. Open visual Studio Code and install following extensions:
2. C# by Microsoft
3. .Net Core Test Explorer by Jun Han
4. Test Explorer UI (Should get installed automatically when above extension is installed)
5. Restart Visual Studio Code if Prompted
6. Click File then click Open and select Solution folder named XenetaWebApp.Tests
7. Press Control + Shift + B to build the solution
8. Go to Test Explorer on left menu to view all features and their tests
9. You can run all tests or a features tests or a single test

# Project Structure/Flow
1. To see tests structure go to Solution Explorer
2. The tests are defined in feature files in Feature folder
3. Feature files map to corresponding step definitions in Steps folder. These steps call test functions in repective page classes
4. Page classes in the Pages folder use selenium to locate elements, perform actions and return properties
5. Browser initialization and dispose is done in WebDriverHooks.cs in Hooks folder
