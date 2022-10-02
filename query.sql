CREATE TABLE Products(name VARCHAR(64) PRIMARY KEY);
CREATE TABLE Categories(name VARCHAR(64) PRIMARY KEY);

CREATE TABLE Relations(
product_name VARCHAR(64) FOREIGN KEY REFERENCES Products,
category_name VARCHAR(64) FOREIGN KEY REFERENCES Categories
);

INSERT INTO Categories values('1'), ('2'), ('3'), ('4');
INSERT INTO Products values('1'), ('2'), ('3'), ('4');

INSERT INTO Relations values('1', '2'), ('1', '3'), ('1', '1'), ('2', '2'), ('3', '1');

SELECT Products.name, Relations.category_name as category  FROM Products LEFT JOIN Relations ON Products.name = Relations.product_name;