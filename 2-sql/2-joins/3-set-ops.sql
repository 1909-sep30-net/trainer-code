-- SQL has some operators that combine entire queries (SELECT) into one query.
-- the set operators:
--  - UNION
--     gives you all rows that are found in either query, without duplicates
--  - UNION ALL
--     gives you all rows found in either query, period, including duplicates.
--     (faster to run, but have potentially more data)
--  - INTERSECT
--     all rows that are in both queries. (no duplicates)
--  - EXCEPT
--     "set difference"
--     all rows that are in the first query but are not in the second query.

-- to use any of them, the two queries must have the same
-- number and type of columns.

-- all first names of employees and customers
SELECT FirstName FROM Employee
UNION
SELECT FirstName FROM Customer;

-- INTERSECT
-- names that a customer has and also an employee has
SELECT FirstName FROM Employee
INTERSECT
SELECT FirstName FROM Customer;

-- EXCEPT
-- names that employees have but customers do not have
SELECT FirstName FROM Employee
EXCEPT
SELECT FirstName FROM Customer;