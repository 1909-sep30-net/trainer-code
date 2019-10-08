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

-- SELECT statement has several "clauses"

-- SELECT clause specifies what columns to have in the result set
-- FROM clause specifies what table to query
-- WHERE clause defines a condition, filtering out rows that don't match
-- GROUP BY clause aggregates multiple rows into one, if they have the same values
--     for all the expressions in the group by list.
-- HAVING clause defines a condition for filtering, but AFTER the group by.
-- ORDER BY clause specifies the sort order of the result set.

-- number of customers in DB
SELECT COUNT(*)
FROM Customer;

SELECT *
FROM Customer;

-- duplicate first names across customers in alphabetical order
SELECT FirstName, COUNT(*) AS DuplicateCount
FROM Customer
-- WHERE COUNT(*) > 1  <- not possible - WHERE runs before GROUP BY
GROUP BY FirstName
HAVING COUNT(*) > 1
ORDER BY FirstName;

-- logical order of operations to the SELECT statement
-- 5. SELECT
-- 1. FROM
-- 2. WHERE
-- 3. GROUP BY
-- 4. HAVING
-- 6. ORDER BY
