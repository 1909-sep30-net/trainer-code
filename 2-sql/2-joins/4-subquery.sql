-- sometimes the most natural way to express a query

-- every track that has never been purchased.
-- subquery version
SELECT * FROM Track WHERE TrackId NOT IN (
    SELECT TrackId FROM InvoiceLine
);

-- there is a syntax called "common table expression" (CTE)
-- it lets you run one query in advance, put it in a temporary variable,
-- and use it in the "main query"
WITH purchased_tracks AS (
    SELECT TrackId FROM InvoiceLine
)
SELECT * FROM Track WHERE TrackId NOT IN (
    SELECT * FROM purchased_tracks
);

-- join version
SELECT Track.*
FROM Track LEFT JOIN InvoiceLine ON Track.TrackId = InvoiceLine.TrackId
WHERE InvoiceLine.InvoiceLineId IS NULL;

-- you can't do "= NULL" in SQL, it will always be false
-- - we have IS NULL and IS NOT NULL

-- set operator version (but we only get the IDs)
SELECT TrackId FROM Track
EXCEPT
SELECT TrackId FROM InvoiceLine;