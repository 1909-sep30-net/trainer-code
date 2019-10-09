-- Data Definition Language
-- CREATE, ALTER, DROP
-- e.g. CREATE TABLE, CREATE FUNCTION, CREATE TRIGGER, CREATE VIEW

-- in SQL, every object (e.g. table) must be in a schema

-- SQL Server has a default schema named dbo

CREATE SCHEMA Poke;
GO

--DROP TABLE Poke.Pokemon;
CREATE TABLE Poke.Pokemon (
    PokemonId INT NOT NULL IDENTITY(1000, 1),
    Name NVARCHAR(50) NOT NULL,
    Height DECIMAL(6,2) NULL,
    TypeId INT NOT NULL FOREIGN KEY REFERENCES Poke.Type (TypeId),
    DateModified DATETIME2 NOT NULL DEFAULT (GETDATE()),
    CONSTRAINT CK_Height_Nonnegative CHECK (Height IS NULL OR Height >= 0)
);

INSERT INTO Poke.Type (TypeId, Name) VALUES (1, 'Water');

INSERT INTO Poke.Pokemon (Name, Height, TypeId) VALUES
('Squirtle', 25, 1);



UPDATE Poke.Pokemon SET PokemonId = 50;

SELECT * FROM Poke.Pokemon;

ALTER TABLE Poke.Pokemon ADD CONSTRAINT
    PK_PokemonId PRIMARY KEY (PokemonId);

--DROP TABLE Poke.Type;
CREATE TABLE Poke.Type (
    TypeId INT NOT NULL,
    Name NVARCHAR(30) NOT NULL,
    CONSTRAINT PK_TypeId PRIMARY KEY (TypeId)
);

ALTER TABLE Poke.Pokemon ADD CONSTRAINT
    FK_TypeId_Type FOREIGN KEY (TypeId) REFERENCES Poke.Type (TypeId);

ALTER TABLE Poke.Pokemon ADD
    Weight DECIMAL(6,2);

ALTER TABLE Poke.Pokemon DROP COLUMN
    Weight;

DROP TABLE Poke.Pokemon;

-- constraints:
--    NOT NULL - column does not accept NULL as a value.
--    NULL     - column explicitly accepts NULL as a value.
--               (NULL will be the default value)
--    PRIMARY KEY - implies NOT NULL and UNIQUE,
--                  and by default sets a CLUSTERED INDEX.
--    UNIQUE   - value must be unique within this column
--    FOREIGN KEY - by default sets a NONCLUSTERED INDEX
--    CHECK    - enforces that some expression is true for every row
--    DEFAULT  - configures a default value for that column
--    IDENTITY - this sets up an auto-incrementing default,
--               AND prevents anyone from inserting their own value