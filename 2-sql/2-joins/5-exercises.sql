-- exercises

-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?
-- join version
SELECT * FROM Artist
EXCEPT
SELECT ar.* FROM Artist AS ar
    LEFT JOIN Album AS al ON ar.ArtistId = al.ArtistId
    LEFT JOIN Track AS t ON al.AlbumId = t.AlbumId
    LEFT JOIN Genre AS g ON t.GenreId = g.GenreId
WHERE g.Name = 'Latin';

-- unfinished subquery version
SELECT * FROM Artist
WHERE ArtistId NOT IN (
    SELECT AlbumId FROM Album WHERE 
    SELECT TrackId FROM Track WHERE GenreId = (
        SELECT GenreId FROM Genre WHERE Name = 'Latin'
    )
);

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.
