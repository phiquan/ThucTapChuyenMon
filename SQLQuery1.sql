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
	IDInforBill int PRIMARY KEY,
	IDFood int,

	FOREIGN KEY(IDFood) REFERENCES Food(IDFood)
)

create table Bill
(
	IDBill int PRIMARY KEY,
	IDStaff int,
	DateBill date,
	IDInforBill int,
	TotalPrice int,

	FOREIGN KEY (IDInforBill) REFERENCES InforBill(IDInforBill),
	FOREIGN KEY (IDStaff) REFERENCES Staff(IDStaff)
)

create table Kho
(
	ID int PRIMARY KEY,
	Name nvarchar(50),
	Number int,
)

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


SELECT * FROM Staff where Email='b'

select IDFood as 'Tên Sản Phẩm',ID as 'Tên Sản Phẩm Cấu Thành', Number as 'Số Lượng'
from InforFood

update Kho Set Number=450 Where ID=11
update Kho Set Name=N'Nước ngọt' Where ID=13

select NameFood as 'Tên Sản Phẩm',Name as 'Tên Sản Phẩm Cấu Thành',InforFood.Number as 'Số Lượng' from  Food, InforFood,  Kho where Food.IDFood = InforFood.IDFood and InforFood.ID = Kho.ID

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

