-- some other objects SQL Server supports

-- we can have "computed columns"
-- the value is computed when read, not stored

-- with option PERSISTED
-- the value IS stored, but lazily
-- value is not recomputed until it needs to be

-- if i want the first letter of the pokemon types
ALTER TABLE Poke.Type ADD
    FirstLetter AS (SUBSTRING(Name, 1, 1)) PERSISTED;

SELECT * FROM Poke.Type;

UPDATE Poke.Type SET Name = 'Fire';

-- similar in spirit to computed columns, we have
-- computed tables, "views"

ALTER TABLE Poke.Pokemon ADD
    Active BIT NOT NULL DEFAULT 1;

GO
CREATE VIEW Poke.ActivePokemon AS
    SELECT * FROM Poke.Pokemon WHERE Active = 1;

UPDATE Poke.ActivePokemon SET Active = 0
WHERE PokemonId < 1002;

SELECT * FROM Poke.ActivePokemon;
SELECT * FROM Poke.Pokemon;

GO
CREATE VIEW Poke.WeirdView WITH SCHEMABINDING AS
    SELECT PokemonId * 2 AS PokemonId, Name + '!' AS Name
    FROM Poke.Pokemon;
GO
DROP VIEW Poke.WeirdView;
DROP TABLE Poke.Pokemon;

-- WITH SCHEMABINDING sets up a "hard" reference from the view
-- to the table, such that the view prevents any changes
-- to that table that would break the view's query

SELECT * FROM Poke.WeirdView;
DELETE FROM Poke.WeirdView WHERE PokemonId = 2000;
UPDATE Poke.WeirdView SET Name = 'Charmander';

-- sometimes we want to store intermediate values,
-- split queries into several parts
-- SQL Server supports scalar variables and table-valued variables
-- they only exist for the duration of that "batch" of commands

DECLARE @maxid INT;
SELECT @maxid = MAX(TypeId) FROM Poke.Type;
SET @maxid = (SELECT MAX(TypeId) FROM Poke.Type); -- another way to set variable
INSERT INTO Poke.Type (TypeId, Name) VALUES (@maxid + 1, 'Earth');

--table-valued variables
DECLARE @@mytable AS TABLE (
    Id INT,
    Name NVARCHAR(20)
);
INSERT INTO @@mytable
    SELECT TypeId, Name FROM Poke.Type;


-- user-defined functions in SQL Server
GO
CREATE FUNCTION Poke.TotalNumberOfPokemon()
RETURNS INT
AS
BEGIN
    DECLARE @result INT;

    SELECT @result = COUNT(*) FROM Poke.Pokemon;

    RETURN @result;
END
GO

SELECT Poke.TotalNumberOfPokemon();

-- that was a scalar function (it returns a single value)

-- table-valued functions:
GO
CREATE FUNCTION Poke.PokemonWithNameOfLength(@length INT)
RETURNS TABLE
AS
    RETURN (
        SELECT * FROM Poke.Pokemon WHERE LEN(Name) = @length
    );
GO

SELECT * FROM Poke.PokemonWithNameOfLength(8);

-- functions cannot make any changes to the database at all
-- they have "read-only" access.

-- write a function that returns the initials of a customer based on his ID.