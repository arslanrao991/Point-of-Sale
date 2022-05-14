create database IMS
use IMS

select* from Products
insert into Products values(100, 'Screw', '001', '001', 10, 14);
insert into Products values(101, 'Screw1', '002', '001', 10, 14.5);
insert into Products values(102, 'Screw2', '003', '001', 10, 14.7);
insert into Products values(103, 'Screw3', '004', '001', 10, 14.8);
insert into Products values(104, 'Screw4', '005', '001', 10, 14.3);
insert into Products values(105, 'Screw5', '006', '001', 10, 14.4);
insert into Products values(106, 'Screw6', '007', '001', 10, 14.9);
insert into Products values(107, 'Screw7', '008', '001', 10, 17);
insert into Products values(108, 'Screw8', '009', '001', 10, 19);
insert into Products values(109, 'Screw9', '010', '001', 10, 12);

create Table Products(
	ID int NOT NULL PRIMARY KEY,
	Product_Name varchar(50) NOT NULL,
	Product_Description varchar(50),
	Product_Category varchar(50),
	Product_Quantity int,
	Product_Per_Unit_Price float);

select * from Supplier
insert into Supplier values(1, 'Supplier1', '03310010101', 'supplier@gmail.com', 'Faisal Town');
insert into Supplier values(2, 'Supplier2', '03310010101', 'supplier2@gmail.com', 'Faisal Town');
insert into Supplier values(3, 'Supplier3', '03310010101', 'supplier3@gmail.com', 'Faisal Town');
insert into Supplier values(4, 'Supplier4', '03310010101', 'supplier4@gmail.com', 'Faisal Town');
insert into Supplier values(5, 'Supplier5', '03310010101', 'supplier5@gmail.com', 'Faisal Town');

create Table Supplier(
	ID int NOT NULL PRIMARY KEY,
	Supplier_Name varchar(50),
	Supplier_Phone_No varchar(20) NOT NULL,
	Supplier_Email varchar(50),
	Supplier_Address varchar(50));

select* from SupplyingOrder
insert into SupplyingOrder values(1, 1, getdate()-1);
insert into SupplyingOrder values(1, 2, getdate()-1);
insert into SupplyingOrder values(1, 3, getdate()-1);
insert into SupplyingOrder values(1, 4, getdate()-1);

create Table SupplyingOrder(
	Supplier_ID int NOT NULL,
	Order_ID int NOT NULL PRIMARY KEY,
	Supplying_Date Date,
	Total_Bill
	FOREIGN KEY (Supplier_ID) REFERENCES Supplier(ID));

select * from SupplyOrderDetails
insert into SupplyOrderDetails values (1,101);
insert into SupplyOrderDetails values (2,101);
insert into SupplyOrderDetails values (3,102);
insert into SupplyOrderDetails values (4,103);

create Table SupplyOrderDetails(
	Supplying_Order_ID int NOT NULL,
	Product_ID int NOT NULL, 
	PRIMARY KEY(Supplying_Order_ID , Product_ID ),
	FOREIGN KEY(Supplying_Order_ID ) REFERENCES SupplyingOrder(Order_ID ),
	FOREIGN KEY(Product_ID ) REFERENCES Products(ID));


/*create Table Payments()*/

	
select * from Customer
insert into Customer values (1, 'Customer1', '03315566778', 'cust1@gmail.com', 'Johar Town');
insert into Customer values (2, 'Customer2', '03315566779', 'cust2@gmail.com', 'Johar Town');
insert into Customer values (3, 'Customer3', '03315566774', 'cust3@gmail.com', 'Johar Town');
insert into Customer values (4, 'Customer4', '03315672138', 'cust4@gmail.com', 'Johar Town');
insert into Customer values (5, 'Customer5', '03315226778', 'cust5@gmail.com', 'Johar Town');
create Table Customer(
	ID int NOT NULL PRIMARY KEY,
	Customer_Name varchar(50),
	Customer_Phone_No varchar(20) NOT NULL,
	Customer_Email varchar(50),
	Customer_Address varchar(50)
	UNIQUE(Customer_Phone_No));

select * from Sales
insert into Sales values (1,1,getdate(), 2000, 1500, 0);
insert into Sales values (2,4,getdate(), 4000, 1600, 0);
insert into Sales values (3,5,getdate(), 2000, 1000, 0);
insert into Sales values (4,4,getdate(), 2000, 1600, 0);

create Table Sales(
	Sales_ID int NOT NULL PRIMARY KEY,
	Customer_ID int NOT NULL,
	[Date] Date NOT NULL,
	Total_Bill float NOT NULL,
	Paid_Bill float NOT NULL,
	Sales_Flag int NOT NULL,
	FOREIGN KEY (Customer_ID) REFERENCES Customer(ID));

select * from SalesDetails
insert into SalesDetails values (1,101, 100, 14);
insert into SalesDetails values (2,101, 20, 14);
insert into SalesDetails values (3,101, 200, 14);

create Table SalesDetails(
	Sales_ID int NOT NULL,
	Product_ID int NOT NULL,
	Quantity int NOT NULL,
	Per_Unit_Price float NOT NULL,
	PRIMARY KEY(Sales_ID , Product_ID),
	FOREIGN KEY (Sales_ID) REFERENCES Sales(Sales_ID),
	FOREIGN KEY (Product_ID) REFERENCES Products(ID));

select * from Accured_Payments /*Accrued payments*/ 
insert into Accured_Payments values (1, 1, 500);
insert into Accured_Payments values (2, 4, 600);
insert into Accured_Payments values (3, 5, 500);


create Table Accured_Payments(
	Receipt_ID int NOT NULL Primary Key,
	Customer_ID int NOT NULL,
	Paid_Price float NOT NULL,
	FOREIGN KEY(Customer_ID) REFERENCES Customer(ID));


/* Cutomer Details with total bill and remaining balance */
select Paid_Bills.ID, Paid_Bills.Customer_Name, Paid_Bills.Customer_Phone_No,Paid_Bills.Customer_Email,Paid_Bills.Customer_Address, Paid_Bills.Total_Purchases  ,(Paid_Bills.Total_Purchases - (Paid_Bills.Paid_Bill+Accured_Payments_Table.Accured_Payment)) as Balance
From
	(select C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address, SUM(S.Total_Bill) as Total_Purchases, (Sum(S.Paid_Bill)) as Paid_Bill
	From Customer as C left join Sales as S on C.ID=S.Customer_ID 
	Group by C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address) as Paid_Bills left join

	(select C.ID, SUm(AP.Paid_Price) as Accured_Payment
	From Customer as C join Accured_Payments as AP on C.ID=AP.Customer_ID
	Group by C.ID) as Accured_Payments_Table on Paid_Bills.ID=Accured_Payments_Table.ID


CREATE PROCEDURE GetCutomerRecord
AS
BEGIN
select Paid_Bills.ID, Paid_Bills.Customer_Name, Paid_Bills.Customer_Phone_No,Paid_Bills.Customer_Email,Paid_Bills.Customer_Address, Paid_Bills.Total_Purchases  ,(Paid_Bills.Total_Purchases - (Paid_Bills.Paid_Bill+Accured_Payments_Table.Accured_Payment)) as Balance
From
	(select C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address, SUM(S.Total_Bill) as Total_Purchases, (Sum(S.Paid_Bill)) as Paid_Bill
	From Customer as C left join Sales as S on C.ID=S.Customer_ID 
	Group by C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address) as Paid_Bills left join

	(select C.ID, SUm(AP.Paid_Price) as Accured_Payment
	From Customer as C join Accured_Payments as AP on C.ID=AP.Customer_ID
	Group by C.ID) as Accured_Payments_Table on Paid_Bills.ID=Accured_Payments_Table.ID
	Return;
END

CREATE PROCEDURE GetSearchedCutomerRecord
@id int,
@name varchar(50),
@phone varchar(20)
AS
BEGIN
select Paid_Bills.ID, Paid_Bills.Customer_Name, Paid_Bills.Customer_Phone_No,Paid_Bills.Customer_Email,Paid_Bills.Customer_Address, Paid_Bills.Total_Purchases  ,(Paid_Bills.Total_Purchases - (Paid_Bills.Paid_Bill+Accured_Payments_Table.Accured_Payment)) as Balance
From
	(select C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address, SUM(S.Total_Bill) as Total_Purchases, (Sum(S.Paid_Bill)) as Paid_Bill
	From Customer as C left join Sales as S on C.ID=S.Customer_ID 
	Group by C.ID, C.Customer_Name, C.Customer_Phone_No, C.Customer_Email, C.Customer_Address) as Paid_Bills left join

	(select C.ID, Sum(AP.Paid_Price) as Accured_Payment
	From Customer as C join Accured_Payments as AP on C.ID=AP.Customer_ID
	Group by C.ID) as Accured_Payments_Table on Paid_Bills.ID=Accured_Payments_Table.ID
Where Paid_Bills.ID=@id or Paid_Bills.Customer_Name like @name+'%' or Paid_Bills.Customer_Phone_No like @phone+'%' 
	Return;
END


drop procedure GetCutomerRecord

SELECT SalesDetails.*, Sales.Customer_ID FROM SalesDetails join Sales on SalesDetails.Sales_ID=Sales.Sales_ID ORDER BY Sales_ID DESC


CREATE TYPE [dbo].[MyTableType] AS TABLE(
    Product_Id int NOT NULL,
    Quantity int NULL,
	Price float
)

create Procedure ProcessSalesTransaction (@cart MyTableType readonly, @products_count int, @phone varchar(20), @total float, @paid float)
As Begin
Begin Transaction
Save Transaction recent;
	DECLARE @Counter INT, @id int, @sid int, @quantity int, @result int, @ph varchar(20), @if_Ph_exist int, @per_unit_price float,
		@if_sales_table_is_empty int
	SET @Counter=1
	SET @ph = @phone

	/*Customer*/
	SELECT @if_Ph_exist=COUNT(A.ID) from(select Customer.ID from Customer where Customer.Customer_Phone_No = @ph) as A
	if (@if_Ph_exist = 0)
	begin
		select top 1 @id = Customer.ID+1 From Customer order by ID desc
		insert into Customer values(@id, 'Default',  @ph, '', '');
	end
	else 
	begin
		select @id = Customer.ID from Customer where Customer.Customer_Phone_No = @ph
	end
	/*Sales*/
	SELECT @if_sales_table_is_empty=COUNT(A.Sales_ID) from(select Sales.Sales_ID from Sales) as A
	if (@if_sales_table_is_empty = 0)
	begin
		set @sid = 1
	end
	else 
	begin
		select top 1 @sid = Sales.Sales_ID + 1 from Sales order by Sales.Sales_ID desc
	end
	insert into Sales values(@sid, @id, getdate(), @total, @paid, 0);

	/*Updating Products and Sales Details*/
	WHILE ( @Counter <=  @products_count)
	BEGIN
		Begin Try
			select Distinct @id = TopN.Product_ID, @quantity = TopN.Quantity, @per_unit_price = TopN.Price from (
				select *, dense_rank() over(order by C.Product_ID)r from @cart as C) as TopN
			where r=@Counter

			Update Products set Product_Quantity -= (@quantity)
			Where Products.Id= @id

			insert into SalesDetails values(@sid, @id, @quantity, @per_unit_price);

		End Try

		Begin Catch
			rollback Transaction recent;
			set @result = 0
			break
		End Catch
		SET @Counter  = (@Counter  + 1)
	END
	commit Transaction
	set @result = 1
	return @result;
End
	
drop procedure ProcessSalesTransaction

/*-----------------------*/
select * from (
				select Distinct *, dense_rank() over(order by C.ID)r from Products as C) as TopN
			where r=5

DECLARE @Counter INT, @id int, @sid int, @quantity int, @result int, @ph varchar(20), @if_Ph_exist int, @per_unit_price float,
		@if_sales_table_is_empty int
	SET @Counter=1
	SET @ph = '03094233623'

	/*Customer*/
	SELECT @if_Ph_exist=COUNT(A.ID) from(select Customer.ID from Customer where Customer.Customer_Phone_No = @ph) as A
	if (@if_Ph_exist = 0)
	begin
		select top 1 @id = Customer.ID+1 From Customer order by ID desc
		insert into Customer values
		(@id, 'Default',  @ph, '', '');
		
	end
	else 
	begin
		select @id = Customer.ID from Customer where Customer.Customer_Phone_No = @ph
	end
	/*Sales*/
	SELECT @if_sales_table_is_empty=COUNT(A.Sales_ID) from(select Sales.Sales_ID from Sales) as A
	if (@if_sales_table_is_empty = 0)
	begin
		set @sid = 1
	end
	else 
	begin
		select top 1 @sid = Sales.Sales_ID + 1 from Sales order by Sales.Sales_ID desc
	end
	print(@id)
	print(@sid)
	insert into Sales values(@sid, @id, getdate(), 100, 10, 0);

select* from customer
select* from Sales
delete from sales where Sales.Sales_ID=6
drop table Sales
drop table SalesDetails



