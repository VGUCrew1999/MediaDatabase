# MediaDatabase
Final Project for Code KY Software Dev II

#Instructions for running
This app requires HeidiSQL and XAMPP Control Panel to connect to the database. 
First, start up XAMMP and make sure Apache and MySQL are both active. You may need to run XAMPP as an administrator.
Next, run HeidiSQL and create a new session. Make sure that the port in HeidiSQL matches the port that MySQL lists in XAMPP. You can make the user and password anything you want, but leave the rest default.
Open the session you created in HeidiSQL, then open and run the CreateDB.sql file. It should create and prepopulate the database and the 2 tables. 
Leave both HeidiSQL and XAMPP running while running the Visual Studio project. They are both must be running to connect to the database.
Now, open the Visual Studio solution and update the connection string under MediaContext.cs if necessary so that it matches what you entered for the HeidiSQL session file.

#Changes from original project plan

The original planned features were: log file, a generic class, the project would be asynchronous, 3 or more unit tests.

The current planned features are: log file, query the database with a raw SQL query, 3 or more unit tests and a list populated with values and used in the program.

Log file - external file tracking user input, important events and errors. it can also be printed to the user.
Unit tests - 6 in total, testing adding, editing, and deleting a movie and a game.
List of values - a list of video games used in the search function, along with a list of movies used in the same way.
Raw SQL query - GetAllMovies() retrieves every movie in the database using a raw sql query with its result converted to a list.

#How the menu works

The menu used in this program is in the console. It will list the available options and the user chooses what they want by entering a number.
Example: Enter 1 to go the add records menu, or 5 to view the log file contents.
When searching or editing a record, it will give prompts on what to enter (a name, a year, etc). It will also tell if an error occurs.

#notes about the log file
The default location for it is in the bin -> debug -> net6.0 folder. It will timestamp every message and will list what menus it entered/exited, user input and actions, and tell if an error has occured. The location can be updated by editing the GetFilePath() method inside FileLogic.cs.