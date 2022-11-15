--create database PizzaApp;

--create table RegisterTable (CustId int primary key identity , CustName varchar(50) not null,Custmobile  varchar(10) unique not null,CustAddres varchar(max) not null,CustPinCode bigint not null);

--drop table RegisterTable;

--insert into RegisterTable(CustName,Custmobile,CustAddres,CustPinCode) values  ('Ajay Kumar R','7502449969','Ammmayappan Nagar Woriur Trichy',620012);

--select * from RegisterTable;

--create table PizzaInformation (pizzaid varchar(100) primary key ,pizzaname varchar(45) unique not null,pizzadescription varchar(30) Not null,pizzaprice int,pizzaimg varchar(max));

--drop table PizzaInformation;

--insert into pizzainformation (pizzaid,pizzaname,pizzadescription,pizzaprice,pizzaimg) values ('pizza_1','cheese crispy chicken tacky','deicious when you eat',5.3,'/image/pizza-3.jpg')
--insert into pizzainformation (pizzaname,pizzadescription,pizzaprice,pizzaimg) values ('margarita with added pasta','deicious when you eat',3.3,'/image/pizza-3.jpg')
--insert into pizzainformation (pizzaname,pizzadescription,pizzaprice,pizzaimg) values ('margarita filled with tomato','deicious when you eat',4.3,'/image/pizza-3.jpg')
--insert into pizzainformation (pizzaname,pizzadescription,pizzaprice,pizzaimg) values ('peppercorn hot chicken ','deicious when you eat',5.3,'/image/pizza-3.jpg')

--select * from PizzaInformation;

--select * from RegisterTable;

--drop table Employee;

--create table CustomerRecord(Orderid int identity primary key,CustId  int foreign key references RegisterTable(CustId),Quantity int not null, Total_Amount int not null);

--drop table CustomerRecord;

--exec sp_help RegisterTable;

--select * from CustomerRecord;

--truncate table CustomerRecord;

--drop trigger IdIncreament;

--create trigger idincreament on pizzainformation  instead of  insert 
--as
--begin
--declare @id varchar(max)
--declare @pid varchar(max) 
--declare @integer int 
--set @id = (select substring(max(pizzaid),7,len(max(pizzaid))) from pizzainformation)
--set @integer = cast(@id as int) + 1
--set @pid = 'pizza_' +  cast(@integer as varchar(max));
--insert into pizzainformation  select @pid,inserted.pizzaname,inserted.pizzadescription,inserted.pizzaprice,inserted.pizzaimg from inserted;
--end





--select * from CustomerRecord;

--insert into CustomerRecord (CustId,Quantity,Total_Amount) values (1,5,15);

--select * from RegisterTable;

--use PizzaApp;


--select *  from sys.tables;
