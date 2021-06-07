Create database TTCM

use TTCM

--Manager (IDMa, Name, Email, Pass, PhoneNumber, Address, DateOfBirth)
--Staff (IDAcount,Name,Email,Pass, Gender)
--Food (IDFood, NameFood, Price) combo1
--InforFood (IDIFFood, IDFood, Name, Number, NSX, HSD) **Gà, Nước Ngọt, Sala, Bánh Mì, ...
--Bill (IDBill, IDAcount, Date, InfoBill, TotalPrice)
--InforBill ( InforBill, IDFood)
--Kho(ID, name, number, )

create table Manager
(
	IDMa int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(50),
	Email nvarchar(50) UNIQUE NOT NULL,
	Pass nvarchar(50) NOT NULL, 
	PhoneNumber int,
	Addr nvarchar(50),
	DateOfBirth date, 
)

create table Staff
(
	IDStaff int IDENTITY(1,1) PRIMARY KEY,
	NameStaff nvarchar(50),
	Email nvarchar(50) UNIQUE NOT NULL,
	Pass nvarchar(50) NOT NULL,
	Gender nvarchar(50), 	
)

create table Food
(
	IDFood int PRIMARY KEY,
	NameFood nvarchar(50),
	Price int,
) 

create table InforFood
(
	IDInforFood int IDENTITY(1,1) PRIMARY KEY,
	IDFood int ,
	ID int,
	Number int,

	FOREIGN KEY (IDFood) REFERENCES Food(IDFood),
	FOREIGN KEY (ID) REFERENCES Kho(ID)
)


create table InforBill
(
	IDInforBill int IDENTITY(1,1) PRIMARY KEY,
	IDFood int,
	IDBill int,
	Number int,
	

	FOREIGN KEY(IDBill) REFERENCES Bill(IDBill),
	FOREIGN KEY(IDFood) REFERENCES Food(IDFood)
)

create table Bill
(
	IDBill int IDENTITY(1,1) PRIMARY KEY,
	IDStaff int,
	DateBill date,
	TimeBill time,
	TotalPrice int,
	FOREIGN KEY (IDStaff) REFERENCES Staff(IDStaff)
)



create table Kho
(
	ID int PRIMARY KEY,
	Name nvarchar(50),
	Number int,
)




--test SQL
begin

		--Manager--
	INSERT INTO Manager(Name,Email,Pass,PhoneNumber,Addr,DateOfBirth) VALUES('phiquan','phiquan2509@gmail.com','123','898043575','An Giang','2000-09-25')


	--Staff--
	INSERT INTO Staff Values('Vo Phi Quan','phiquan@gmail.com','123','Nam')

	--Food--
	INSERT INTO Food Values('1','combo1',79000)
	INSERT INTO Food Values('2','combo2',129000)

	

	--InforFood--
	--combo1--
	INSERT INTO InforFood Values(1,11,1)
	INSERT INTO InforFood Values(1,13,1)
	--combo2--
	INSERT INTO InforFood Values(2,11,2)
	INSERT INTO InforFood Values(2,12,1)

	INSERT INTO InforFood Values(3,11,2)
	INSERT INTO InforFood Values(3,12,1)

	
	delete from InforFood where IDFood=3
	delete from Food where IDFood=3
	--KHO--
	INSERT INTO Kho Values('11','Gà miếng',500)
	INSERT INTO Kho Values('12','Sandwich',200)
	INSERT INTO Kho Values('13','Nước ngọt',400)
	

end

--test SQL
begin

	SELECT * FROM Staff where Email='b'

	select IDFood as 'Tên Sản Phẩm',ID as 'Tên Sản Phẩm Cấu Thành', Number as 'Số Lượng'
	from InforFood

	update Kho Set Number=450 Where ID=11
	update Kho Set Name=N'Nước ngọt' Where ID=13

	select Kho.ID ,NameFood as 'Tên Sản Phẩm',Name as 'Tên Sản Phẩm Cấu Thành',InforFood.Number as 'Số Lượng' 
	from  Food, InforFood,  Kho 
	where Food.IDFood = InforFood.IDFood and InforFood.ID = Kho.ID and Food.IDFood=2

	select * from Kho where ID=11

	Delete from Kho where ID=14

	select * 
	from InforFood, Kho
	where InforFood.ID=Kho.ID and Kho.ID=14

	Update Food Set NameFood=N'comb1', Price=69000 Where IDFood=1
	insert into Food values(3,'combo3',159000)


	select * 
	from InforFood
	where IDFood=2

	select ID 
	from Kho
	where Name=N'Gà miếng'

	insert into InforFood values(1,11,2)

	delete from InforFood where IDFood=2

	select *from InforFood where IDFood=2 and ID=14


	update InforFood Set ID=11, Number=3 Where ID=12 and IDFood=2
	delete from InforFood where IDFood=3 and ID=11

	create table test
	(
		id int PRIMARY KEY,
		name nvarchar(50),
		price int,
		ngay date,
		gio time
	)

	insert into test(id,name,ngay,gio) values(3,'quan','2022/06/03','21:53:05')
	update test set price=10 where id=1
	drop table test
	select * from test

	select * from Staff where Email='phiquan@gmail.com'and pass='123'

	select * from test where name='quan' and ngay='2021/06/03'and gio>'22:00:00'

	select * from InforBill

	drop table InforBill
	drop table Bill

	select Food.IDFood, Food.NameFood, SUM(Food.Price) as 'Thành Tiền', SUM(Number) as N'Số Lượng'
	from InforBill, Food
	where IDBill=InForBill.IDBill and InforBill.IDFood=Food.IDFood and IDBill=1
	Group By Food.NameFood , Food.Price, Food.IDFood

	select SUM(Food.Price) as 'Thành Tiền'
	from InforBill,Food
	where InforBill.IDFood=Food.IDFood and IDBill=1
	Group By IDBill

	select


	insert into InforBill values(1,1,1)
	insert into InforBill values(2,1)
	insert into InforBill values(3,1)

	select * from Food

	select * from Bill
	insert into Bill values(7,'2020/06/04','12:00:00',120000)

	insert into Bill values(7,'2020/06/04','13:00:00',120000)

	insert into Bill values(7,'2020/06/04','14:00:00',120000)

	insert into Bill values(7,'2020/06/04','15:00:00',120000)

	insert into Bill values(7,'2020/06/04','16:00:00',120000)

	insert into Bill values(7,'2020/05/04','16:00:00',120000)

	insert into Bill(IDStaff,DateBill,TimeBill) values(7,'2021/06/04','12:39:00')

	insert into Bill(IDStaff,DateBill,TimeBill) values(7,'2021/06/04','13:24:00')

	select *
	from Bill
	Where DateBill = '2021/06/04' and TimeBill = '13:24:00'


	update Bill set TotalPrice=129000 where IDStaff=7 and DateBill='2021/06/04' and TimeBill='12:39:00'

	select * from Bill where IDStaff=7 and DateBill='2021/06/04' and TimeBill>=''

	delete from InforBill where IDBill=8
	delete from Bill where IDBill=8


	select Kho.Name, SUM(Kho.Number) as 'Số Lượng'
	from Bill, InforFood, InforBill, Kho, Food
	where Bill.IDStaff = 1 and Date=''

	select *
	from Bill
	where IDStaff=7 and TimeBill>'06:20:00' and DateBill='2021/06/04'


	select InforBill.IDFood, Number
	from Bill, InforBill, Food
	where IDStaff=7 and TimeBill>'06:20:00' and DateBill='2021/06/04' 
		and Bill.IDBill=InforBill.IDBill and Food.IDFood=InforBill.IDFood



	select InforFood.IDInforFood, InforFood.Number , InforBill.Number
	from Bill, InforBill, Food, InforFood
	where IDStaff=7 and TimeBill>'06:20:00' and DateBill='2021/06/04' 
		and Bill.IDBill=InforBill.IDBill and Food.IDFood=InforBill.IDFood
		and InforBill.IDFood=InforFood.IDFood


	select InforFood.ID, SUM(InforFood.Number) as'SL' 
	from Bill, InforBill, Food, InforFood
	where IDStaff=7 and TimeBill>'11:16:00' and DateBill='2021/06/04' 
		and Bill.IDBill=InforBill.IDBill and Food.IDFood=InforBill.IDFood
		and InforBill.IDFood=InforFood.IDFood
	Group By InforFood.ID

	select Kho.ID, Kho.Name, SUM(InforFood.Number) as'SL' 
	from Bill, InforBill, Food, InforFood, Kho
	where IDStaff=7 and TimeBill>'11:16:00' and DateBill='2021/06/04' 
		and Bill.IDBill=InforBill.IDBill and Food.IDFood=InforBill.IDFood
		and InforBill.IDFood=InforFood.IDFood
		and Kho.ID=InforFood.ID
	Group By Kho.Name, Kho.ID


	select * from Kho 

	update Kho set Number
end


update Kho set Number=Number+10 where ID=11


select InforFood.ID, SUM(InforFood.Number)
from Bill, InforBill, Food, InforFood,Kho
where Bill.IDBill=66 and InforBill.IDFood=Food.IDFood and InforBill.IDBill=Bill.IDBill and Food.IDFood=InforFood.IDFood and InforFood.ID=Kho.ID
Group By InforFood.ID