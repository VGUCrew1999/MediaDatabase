DROP DATABASE IF EXISTS MediaDatabase;
CREATE DATABASE IF NOT EXISTS MediaDatabase;

USE MediaDatabase;

# creates tables and resets them to default
DROP TABLE IF EXISTS VideoGames;
CREATE TABLE IF NOT EXISTS VideoGames(
	GameID VARCHAR(6) NOT NULL,
	GameName VARCHAR(255) NOT NULL,
	Console VARCHAR(255),
	Developer VARCHAR(255),
	Publisher VARCHAR(255),
	ReleaseDate DATE,
	DateAdded DATE,
	PRIMARY KEY (GameID)
);

DROP TABLE IF EXISTS Movies;
CREATE TABLE IF NOT EXISTS Movies(
	MovieID VARCHAR(6) NOT NULL,
	MovieName VARCHAR(255) NOT NULL,
	LengthMinutes INT,
	Director VARCHAR(255),
	Producer VARCHAR(255),
	ReleaseDate DATE,
	DateAdded DATE,
	PRIMARY KEY (MovieID)	
);

#populates tables
INSERT INTO videogames (GameID, GameName, Console, Developer, Publisher, ReleaseDate, DateAdded)
VALUES 
	("SF2002", "Star Fox Adventures", "GameCube", "Rare", "Nintendo", '2002-09-23', CURDATE()),
	("SF2005", "Star Fox Assault", "GameCube", "Namco", "Nintendo", '2005-02-14', CURDATE()),
	("LZ1998", "The Legend of Zelda: Ocarina of Time", "Nintendo 64", "Nintendo EAD", "Nintendo", '1998-11-23', CURDATE()),
	("LZ2006", "The Legend of Zelda: Twilight Princess", "GameCube", "Nintendo EAD", "Nintendo", '2006-12-02', CURDATE());
	
INSERT INTO movies(MovieID, MovieName, LengthMinutes, Director, Producer, ReleaseDate, DateAdded)
VALUES
	("PC2003", "Pirates of the Caribbean: The Curse of the Black Pearl", 143, "Gore Verbinski", "Jerry Bruckheimer", '2003-07-09', CURDATE()),
	("FF2001", "The Fast and the Furious", 106, "Rob Cohen", "Neal H. Moritz", '2001-06-22', CURDATE()),
	("SK2004", "Shrek 2", 92, "Andrew Adamson", "Aron Warner", '2004-05-19', CURDATE()),
	("SM2023", "The Super Mario Bros. Movie", 92, "Aaron Horvath", "Chris Meledandri", '2023-04-05', CURDATE());