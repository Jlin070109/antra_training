--1. How many products can you find in the Production.Product table?
SELECT COUNT(*) FROM Production.Product

--2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
-- The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.
SELECT COUNT(ProductSubcategoryID) FROM Production.Product GROUP BY ProductSubcategoryID

--3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
--ProductSubcategoryID CountedProducts
-------------------- -------------------
SELECT ProductSubcategoryID, COUNT(ProductSubcategoryID) AS CountedProducts FROM Production.Product GROUP BY ProductSubcategoryID

--4. How many products that do not have a product subcategory.
SELECT COUNT(*) AS ProductCount
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--5. Write a query to list the sum of products quantity of each product in the Production.ProductInventory table.
SELECT SUM(Quantity) FROM Production.ProductInventory GROUP BY ProductID

--6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
--             ProductID    TheSum
--             -----------        ----------
SELECT ProductID, SUM(Quantity) AS TheSum FROM Production.ProductInventory WHERE LocationID = 40 GROUP BY ProductID HAVING SUM(Quantity) < 100


--7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table 
-- and LocationID set to 40 and limit the result to include just summarized quantities less than 100
--    Shelf      ProductID    TheSum
--    ----------   -----------        -----------
SELECT Shelf, ProductID, SUM(Quantity) AS TheSum FROM Production.ProductInventory WHERE LocationID = 40 GROUP BY Shelf, ProductID HAVING SUM(Quantity) < 100

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.
SELECT AVG(Quantity) FROM Production.ProductInventory WHERE LocationID = 10

--9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory

    ProductID   Shelf      TheAvg

    ----------- ---------- -----------
SELECT AVG(Quantity) FROM Production.ProductInventory WHERE LocationID = 10 GROUP BY Shelf

--10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
--  ProductID   Shelf      TheAvg
------------- ---------- -----------
SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg FROM Production.ProductInventory WHERE Shelf != 'N/A' GROUP BY ProductID, Shelf

--11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. 
-- Exclude the rows where Color or Class are null.
--   Color       Class          TheCount          AvgPrice
-------------- ---------    -----------        ---------------
SELECT Color, Class, COUNT(*) AS TheCount, AVG(ListPrice) AS AvgPrice FROM Production.Product GROUP BY Color, Class


---------------------------
--Joins:
---------------------------



--12. Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. Join them and produce a result set similar to the following.
--Country       Province
---------    ----------------------
SELECT cr.name AS Country, sp.name AS Province FROM Person.StateProvince sp LEFT JOIN Person.CountryRegion cr ON sp.CountryRegionCode = cr.CountryRegionCode

--13.  Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables and list the countries filter them by Germany and Canada. 
-- Join them and produce a result set similar to the following.
--    Country            Province
--   ---------          ----------------------
SELECT cr.name AS Country, sp.name AS Province FROM Person.StateProvince sp LEFT JOIN Person.CountryRegion cr ON sp.CountryRegionCode = cr.CountryRegionCode 
WHERE cr.name IN ('Germany', 'Canada')


-- Using Northwnd Database: (Use aliases for all the Joins)
USE Northwind

SELECT * FROM [Order Details]
SELECT * FROM Orders
SELECT * FROM Products

-- 14. List all Products that have been sold at least once in the last 27 years.
SELECT DISTINCT p.ProductName FROM dbo.[Order Details] o LEFT JOIN dbo.Products p ON o.ProductID = p.ProductID LEFT JOIN Orders ord ON o.OrderID = ord.OrderID 
WHERE DATEDIFF(year, ord.OrderDate, GETDATE()) <= 27

-- 15. List top 5 locations (Zip Code) where the products sold the most. 
SELECT TOP 5 o.ShipPostalCode, COUNT(o.orderID) FROM Orders o
GROUP BY o.ShipPostalCode
ORDER BY COUNT(o.orderID) DESC
--COUNT(o.orderID) for double check

-- 16. List top 5 locations (Zip Code) where the products sold the most in the last 27 years.
SELECT TOP 5 o.ShipPostalCode, COUNT(o.orderID) FROM Orders o
WHERE DATEDIFF(year, o.OrderDate, GETDATE()) <= 27
GROUP BY o.ShipPostalCode
ORDER BY COUNT(o.orderID) DESC

-- 17. List all city names and the number of customers in that city.
SELECT c.City, COUNT(c.CustomerID) AS CustomerCount FROM Customers c GROUP BY c.City

-- 18. List city names that have more than 2 customers, and the number of customers in that city.
SELECT c.City, COUNT(c.CustomerID) AS CustomerCount FROM Customers c GROUP BY c.City HAVING COUNT(c.CustomerID) > 2

-- 19. List the names of customers who placed orders after 1/1/98 with the order date.
SELECT c.ContactName, o.OrderDate
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

-- 20. List the names of all customers with their most recent order dates.
SELECT c.ContactName, MAX(o.OrderDate) AS recentOrder
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.ContactName

-- 21. Display the names of all customers along with the count of products they bought.
SELECT c.ContactName, SUM(od.Quantity) AS TotalCountofProduct
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.ContactName


-- 22. Display the customer IDs who bought more than 100 products with the count of products.
SELECT c.CustomerID, c.ContactName, SUM(od.Quantity) AS TotalCountofProduct
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.CustomerID, c.ContactName HAVING SUM(od.Quantity) > 100

-- 23. List all the possible ways that suppliers can ship their products. 
--     Display the results as:
--     Supplier Company Name       Shipping Company Name
SELECT s.CompanyName AS 'Supplier Company Name', sh.CompanyName AS [Shipping Company Name]
FROM Suppliers s 
LEFT JOIN Products p ON s.SupplierID = p.SupplierID 
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON od.OrderId = o.OrderId
JOIN Shippers sh ON o.ShipVia = sh.ShipperID
GROUP BY s.CompanyName, sh.CompanyName
ORDER BY s.CompanyName, sh.CompanyName

-- 24. Display the products ordered each day. Show Order Date and Product Name.
SELECT o.OrderDate, p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
ORDER BY o.OrderDate

-- 25. Display pairs of employees who have the same job title.
SELECT * FROM Employees
SELECT * FROM EmployeeTerritories
SELECT e1.FirstName + ' ' + e1.LastName AS Employee1, e2.FirstName + ' ' + e2.LastName AS Employee2, e1.Title
FROM Employees e1
JOIN Employees e2 ON e1.Title = e2.Title AND e1.EmployeeID < e2.EmployeeID
-- The e1.EmployeeID < e2.EmployeeID make sure no duplicate exist and employee1 != employee2

-- 26. Display all the Managers who have more than 2 employees reporting to them.
SELECT e.FirstName + ' ' + e.LastName AS Manager, COUNT(e2.EmployeeID) AS NumberOfEmployees
FROM Employees e
JOIN Employees e2 ON e.EmployeeID = e2.ReportsTo
GROUP BY e.FirstName, e.LastName
HAVING COUNT(e2.EmployeeID) > 2

-- 27. Display the customers and suppliers by city. The result should have the columns:
--     City, Name, Contact Name, Type (Customer or Supplier)
SELECT City, CompanyName AS Name, ContactName, 'Customer' AS Type
FROM Customers
UNION
SELECT City, CompanyName AS Name, ContactName, 'Supplier' AS Type
FROM Suppliers