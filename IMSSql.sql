create database IMS
use IMS

select* from Products

insert into Products values(100, 'Screw', '001', '001', 10, 14);

create Table Products(
	ID int NOT NULL PRIMARY KEY,
	Product_Name varchar(50) NOT NULL,
	Product_Description varchar(50),
	Product_Category varchar(50),
	Product_Quantity int(50),
	Product_Per_Unit_Price float);

create Table Supplier(
	ID int NOT NULL PRIMARY KEY,
	Supplier_Name varchar(50),
	Supplier_Phone_No varchar(20) NOT NULL,
	Supplier_Email varchar(50),
	Supplier_Address varchar(50));

create Table SupplyingOrder(
	Supplier_ID int NOT NULL,
	Order_ID int NOT NULL PRIMARY KEY,
	Supplying_Date Date
	FOREIGN KEY (Supplier_ID) REFERENCES Supplier(ID));



create Table SupplyOrderDetails(
	Supplying_Order_ID int NOT NULL,
	Product_ID int NOT NULL, 
	PRIMARY KEY(Supplying_Order_ID , Product_ID ),
	FOREIGN KEY(Supplying_Order_ID ) REFERENCES SupplyingOrder(Order_ID ),
	FOREIGN KEY(Product_ID ) REFERENCES Products(ID));


/*create Table Payments()*/

	

create Table Customer(
	ID int NOT NULL PRIMARY KEY,
	Customer_Name varchar(50),
	Customer_Phone_No varchar(20) NOT NULL,
	Customer_Email varchar(50),
	Customer_Address varchar(50)
	UNIQUE(Customer_Phone_No));

/*
create Table Batch(
	Batch_ID int NOT NULL PRIMARY KEY,
	Supplier_ID int NOT NULL,
	Batch_Cost float NOT NULL, 
	[Date] Date NOT NULL,
	FOREIGN KEY (Supplier_ID) REFERENCES Supplier(ID)); 


create Table Stock(
	Batch_ID int NOT NULL,
	Product_ID int NOT NULL,
	Purchase_Unit_Cost float NOT NULL,
	Selling_Unit_Cost float NOT NULL,
	Quantity int NOT NULL,
	PRIMARY KEY (Batch_ID, Product_ID),
	FOREIGN KEY (Batch_ID) REFERENCES Batch(Batch_ID),
	FOREIGN KEY (Product_ID) REFERENCES Products(ID));
*/

create Table Sales(
	Sales_ID int NOT NULL PRIMARY KEY,
	Customer_ID int NOT NULL,
	[Date] Date NOT NULL,
	Total_Bill float NOT NULL,
	Paid_Bill float NOT NULL,
	FOREIGN KEY (Customer_ID) REFERENCES Customer(ID));

create Table SalesDetails(
	Sales_ID int NOT NULL,
	Product_ID int NOT NULL,
	Quantity int NOT NULL,
	Per_Unit_Price float NOT NULL,
	PRIMARY KEY(Sales_ID , Product_ID),
	FOREIGN KEY (Sales_ID) REFERENCES Sales(Sales_ID),
	FOREIGN KEY (Product_ID) REFERENCES Products(ID));

create Table Receipt(
	Receipt_ID int NOT NULL Primary Key,
	Customer_ID int NOT NULL,
	Paid_Price float NOT NULL,
	FOREIGN KEY(Customer_ID) REFERENCES Customer(ID));