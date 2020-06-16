# bpdts_test_app
## Task
>"Build an API which calls this API, and returns people who are listed as either living in London, or whose current coordinates are within 50 miles of London. Push the answer to Github, and send us a link."

## Function
Application allows a user to call and API from a web applciation front end. Data returned will display all users that live within London or withing a 50 mile radius of London by default (the distance can be altered). THe application has been built to be flexible to allow for future development of a city selection.

## Prerequisites
- Visual Studio
- .Net Framework

## Dependencies
The following addittional non-standard Nuget packages were utilised: - <br/>
- Newtonsoft.Json
- NUnit
- NUnit3TestAdapter
- Moq
- Bootstrap

## Run Applicataion
- Clone application from https://github.com/LeeGordon83/bpdts_test_app
- Open application folder in Visual Studio (or preferred IDE) and click the bpdts_tes_app.sln file
- Select start debugging (F5)
- Web application will open in selected browser and navigate to localhost.

## Run tests
- Unit tests are written in NUnit utilising Moq.
- Run all tests by selecting Test dropdown then Run All Tests in Visual Studio.
- 95.51% test code coverage

## License
This project is licensed under the MIT License - see the LICENSE.md file for details.
