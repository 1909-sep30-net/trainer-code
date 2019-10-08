-- basics of SQL

-- SQL is declarative - we say what we want, not how to implement that
-- we don't specify exactly how SQL Server will iterate through
-- the data, check caches, etc. - that's its job.

-- with SQL we send commands / queries to a database

-- DML, Data Manipulation Language
-- all operations on individual rows
-- SELECT is for read access (no modifications)
-- the rest of DML and everything else too is for modifications

-- DDL, Data Definition Language
-- all operations on whole tables, table structure, most all
--   other objects in the DB like functions, procedures, triggers, etc.

-- DCL, Data Control Language
-- database administration, allow users to have different permissions

-----------

-- 'just give me the number 1'
SELECT 1;
SELECT 1;

SELECT 2 + 3; -- 5
SELECT 'str1' + ' ' + CONVERT(varchar, 2 + 3);
-- single quotes for string literals
-- the semicolons arent required for anything

-- all employee data (* means every column)
SELECT * 
FROM Employee;

-- fetching only some of the columns
-- the names of all employees
SELECT FirstName, LastName
FROM Employee;

-- fetch only some of the rows
-- all data on employees with first names 5 letters long or shorter
SELECT *
FROM Employee
WHERE LEN(FirstName) <= 5;

SELECT *
FROM Employee
WHERE FirstName = 'STEVE' AND LastName = 'johnson';

-- in SQL, often, string comparison is case-insensitive.
-- this is based on the "collation"
-- the collation is a per-database setting determining
--   the rules for string comparison, standard date/time format
--   number format, currency format, VARCHAR (non-Unicode) string encoding

-- get the full name of each employee as one column, and the length of their names
-- with column aliases - if they have spaces, surrond with [] or ""
SELECT
    FirstName + ' ' + LastName AS [Full Name],
    LEN(FirstName + ' ' + LastName) AS [Length]
FROM Employee;