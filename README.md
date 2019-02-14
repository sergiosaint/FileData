# FileData

Starting solution is available on https://github.com/RobGillies/DeveloperTestExercise

Once complete, could you upload your solution onto your personal GitHub once complete and send me the link?  We’re not looking for a comprehensive solution just to see how you tackle problems so please only spend around 60-90mins on this.


Information for candidate – if they’re not familiar with console apps

Contains FileData which is a console app

Main takes in an array args which is the set of arguments past in from the Console app

 

Contains ThirdPartyTools – **this is a third party app that cannot be changed**

ThirdPartyTools contains FileDetails.cs which has two functions:

* Version which returns a random number
* Size which returns a random number

*We are not looking to test if you know how to access the file system and manage files.  As such, you do not need to check if file exists etc. just pass a string into Version and Size.*

 

To setup test arguments:

* Go to FileData – Properties
* In the Debug tab, enter arguments in  ‘Command line arguments’ start with ‘-v c:/test.txt’

               

We are looking for a production-ready (include testing) piece of code that: 

* Takes in two arguments (argument 1 = functionality to perform, argument 2 = filename)
* If the first argument is anyone of –v, --v, /v, --version then return the version of the file (use FileDetails.Version to get the version number, don’t worry about accessing the file or checking if it exists etc.)
* If the first argument is anyone of –s, --s, /s, --size the return the size of the file (use FileDetails.Size)
