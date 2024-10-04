--1. List all cities that have both Employees and Customers.
--(solution 1)
SELECT City
FROM Employees
INTERSECT
SELECT City
FROM Customers
--(solution 2)
SELECT DISTINCT e.City
FROM Employees e
INNER JOIN Customers c ON e.City = c.City
WHERE e.City IS NOT NULL AND c.City IS NOT NULL;

--2. List all cities that have Customers but no Employee.
--a. Use sub-query
SELECT DISTINCT City
FROM Customers
WHERE City IS NOT NULL 
  AND City NOT IN (SELECT DISTINCT City FROM Employees WHERE City IS NOT NULL)
--b. Do not use sub-query
--(solution 1)
SELECT DISTINCT City
FROM Customers
EXCEPT
SELECT DISTINCT City
FROM Employees
--(solution 2)
SELECT DISTINCT c.City
FROM Customers c
LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL AND c.City IS NOT NULL

--3. List all products and their total order quantities throughout all orders.
SELECT p.ProductName, SUM(od.Quantity) AS "total order quantities"
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID GROUP BY p.ProductName

--4. List all Customer Cities and total products ordered by that city.
SELECT c.City, SUM(od.Quantity) AS "total products ordered"
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City

--5. List all Customer Cities that have at least two customers.
SELECT City FROM Customers GROUP BY City HAVING COUNT(City) >= 2

--6. List all Customer Cities that have ordered at least two different kinds of products.
SELECT c.City
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City HAVING COUNT(od.ProductID) > 2 

--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT DISTINCT c.ContactName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NOT NULL AND c.City != o.ShipCity

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

WITH ProductPopularity AS (
    -- Get the total quantity ordered by each city for each product
    SELECT 
        od.ProductID AS ID, 
        c.City AS City, 
        SUM(od.Quantity) AS CitySum
    FROM Customers c 
    JOIN Orders o ON c.CustomerID = o.CustomerID 
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY od.ProductID, c.City
),
TopProducts AS (
    -- Find the top 5 most popular products based on total quantity sold
    SELECT TOP 5 od.ProductID 
    FROM [Order Details] od 
    GROUP BY od.ProductID 
    ORDER BY SUM(od.Quantity) DESC
),
CityWithMaxQuantity AS (
    -- Find the city that ordered the most quantity for each product
    SELECT 
        pp.ID, 
        pp.City, 
        pp.CitySum,
        RANK() OVER (PARTITION BY pp.ID ORDER BY pp.CitySum DESC) AS Rank
    FROM ProductPopularity pp
    WHERE pp.ID IN (SELECT ProductID FROM TopProducts)
)
-- Select the top city (Rank = 1) for each of the 5 most popular products
SELECT 
    cw.ID AS ProductID, 
    cw.City AS TopOrderingCity, 
    cw.CitySum AS MaxQuantity
FROM CityWithMaxQuantity cw
WHERE cw.Rank = 1;

--9. List all cities that have never ordered something but we have employees there.
--a. Use sub-query
SELECT DISTINCT e.City
FROM Employees e
WHERE e.City IS NOT NULL 
  AND e.City IN (
    SELECT DISTINCT c.City
    FROM Customers c LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
    WHERE o.OrderID IS NULL AND c.City IS NOT NULL
);

--b. Do not use sub-query
SELECT DISTINCT e.City
FROM Employees e
LEFT JOIN Customers c ON e.City = c.City
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderID IS NULL AND c.City IS NOT NULL AND e.City IS NOT NULL

--10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, 
-- and also the city of most total quantity of products ordered from. (tip: join  sub-query)
WITH EmployeeMostOrders AS (
    -- Sub-query to find the city where the employee has sold the most orders
    SELECT TOP 1 e.City, COUNT(o.OrderID) AS OrderCount
    FROM Employees e
    JOIN Orders o ON e.EmployeeID = o.EmployeeID
    WHERE e.City IS NOT NULL
    GROUP BY e.City
    ORDER BY COUNT(o.OrderID) DESC
),
CityMostQuantityOrdered AS (
    -- Sub-query to find the city where the most total quantity of products has been ordered
    SELECT TOP 1 c.City, SUM(od.Quantity) AS TotalQuantity
    FROM Customers c
    JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY c.City
    ORDER BY SUM(od.Quantity) DESC
)
-- Main query to find the city that satisfies both conditions
SELECT e.City
FROM EmployeeMostOrders e
JOIN CityMostQuantityOrdered q ON e.City = q.City;

--11. How do you remove the duplicates record of a table?
-- ANS: Use the keyword DISTINCT