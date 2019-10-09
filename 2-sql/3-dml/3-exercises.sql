-- exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter
UPDATE Customer
SET FirstName = 'Robert', LastName = 'Walter'
WHERE FirstName = 'Aaron' AND LastName = 'Mitchell';

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.
DELETE FROM InvoiceLine WHERE InvoiceId IN (
    SELECT InvoiceId FROM Invoice WHERE CustomerId = (
        SELECT CustomerId FROM Customer
        WHERE FirstName = 'Robert' AND LastName = 'Walter'
    )
);
DELETE FROM Invoice WHERE CustomerId = (
    SELECT CustomerId FROM Customer
    WHERE FirstName = 'Robert' AND LastName = 'Walter'
);
DELETE FROM Customer
WHERE FirstName = 'Robert' AND LastName = 'Walter';