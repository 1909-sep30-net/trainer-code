-- joins combine data back together in a query
-- that was spread out into many tables by the database's design.

-- pair every employee with every other employee
-- (joins do not have to be between two DIFFERENT tables)
-- (must give tables aliases if they have the same name)
SELECT e1.*, e2.*
FROM Employee AS e1
	CROSS JOIN Employee AS e2;

-- cross joins are not always very useful
-- one example: combine toppings, toppings, crusts, and cheeses to make
-- all possible pizzas.
-- length of result is the product of the lengths of the two input tables

-- INNER JOIN
-- like cross join, but discard all result rows except those matching ON condition.

-- each track's name and its genre:
SELECT t.Name, g.Name
FROM Track AS t
	INNER JOIN Genre AS g ON t.GenreId = g.GenreId;

-- if we used LEFT JOIN instead, we would see any tracks
-- that had no genre, with NULL in the second column.

-- all rock songs in the database, showing the name in this format
--  'Artistname - Songname'
-- think about how to handle any possible NULL values
SELECT ar.Name + ' - ' + t.Name
FROM Artist AS ar
	INNER JOIN Album AS al ON ar.ArtistId = al.ArtistId
	RIGHT JOIN Track AS t ON t.AlbumId = al.AlbumId
	LEFT JOIN Genre AS g ON g.GenreId = t.GenreId
WHERE g.Name = 'Rock';

-- equivalent, but writing the joins in different order:
-- (and using COALESCE to handle cases of track missing an artist (NULL).)
SELECT COALESCE(ar.Name, 'Unknown Artist') + ' - ' + t.Name
FROM Track AS t
	LEFT JOIN Album AS al ON t.AlbumId = al.AlbumId
	LEFT JOIN Artist AS ar ON ar.ArtistId = al.ArtistId
	LEFT JOIN Genre AS g ON g.GenreId = t.GenreId
WHERE g.Name = 'Rock';

-- i don't care if there are albums without artists, or artists without tracks

-- another example of COALESCE
SELECT FirstName + ' ' + LastName + ' (' + COALESCE(Company, 'N/A') + ')'
FROM Customer;


SELECT * FROM Employee
-- "self join" is what some people call it when you join
-- a table with itself

-- show me every employee with manager
SELECT emp.FirstName + ' ' + emp.LastName AS Employee,
    man.FirstName + ' ' + man.LastName AS Manager
FROM Employee AS man RIGHT JOIN Employee AS emp
    ON man.EmployeeId = emp.ReportsTo;