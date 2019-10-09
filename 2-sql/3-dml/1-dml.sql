-- the rest of DML... INSERT, UPDATE, DELETE

SELECT * FROM Genre;

INSERT INTO Genre VALUES (100, 'Misc');

-- best practice, name the columns you'll insert, in the order you want
-- (necessary if some of the columns don't allow inserting)
-- (helpful if some of the columns have default values that you want)
INSERT INTO Genre (GenreId, Name) VALUES
    (101, 'Misc 2'),
    (102, 'Misc 3');

-- you can insert values parsed from a CSV file, things like that
-- can insert based on query

INSERT INTO Genre (GenreId, Name) VALUES
    ((SELECT MAX(GenreId) FROM Genre) + 1, 'Misc 4');

INSERT INTO Genre
    SELECT GenreId + 10, Name + '!'
    FROM Genre
    WHERE Name LIKE 'Misc%';

 -- UPDATE

 UPDATE Genre
 SET GenreId = GenreId + 10,
    Name = Name + '!'
 WHERE Name LIKE 'Misc%'; -- without the WHERE, would update every row

 SELECT * FROM Genre WHERE Name LIKE 'Misc%';

 -- DELETE

-- DELETE FROM Genre; -- would delete every row

DELETE FROM Genre
WHERE Name LIKE 'Misc%';

-- removes all rows in a table
--TRUNCATE TABLE Genre;
