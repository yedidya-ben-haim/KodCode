// Part A - GROUP BY and HAVING

//ex 1
// select customers.customerName,
// sum(payments.amount) as toatal_payment
// from customers
// inner join payments
//     on customers.customerNumber = payments.customerNumber
// group by customerName

//ex 2
// use classicmodels;
// select YEAR(o.orderDate), month(o.orderDate), 
// COUNT(orderNumber) AS total 
// from orders as o
//     group by month(o.orderDate)

//ex3
// SELECT customers.country,
// sum(orderdetails.quantityOrdered) as total_quantity,
// sum(orderdetails.quantityOrdered*orderdetails.priceEach) as total_amunt
// from customers
// join orders o on customers.customerNumber = o.customerNumber
// join orderdetails
// on o.orderNumber = orderdetails.orderNumber
// group by customers.country
//     having total_quantity >= 2500
// order by total_amunt asc 

//ex 4
// select p.productLine,
// p.textDescription,
// count(products.productCode) as total_product
// from products
// join productlines p 
//     on products.productLine = p.productLine
// group by p.productLine
//     having total_product >10

//ex 5
// select sum(od.quantityOrdered*od.priceEach),
// year(o.orderDate) AS order_year,
//     p.productLine
//     from orderdetails od
// join orders o 
//     on o.orderNumber = od.orderNumber
// JOIN products AS p
// ON od.productCode = p.productCode
// GROUP BY order_year, p.productLine
//     order by  p.productLine,
// order_year desc 

//ex 6
// SELECT
// o.orderDate,
// DAYNAME(o.orderDate) AS day_of_week
// FROM orders AS o;
