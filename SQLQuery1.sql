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

	

	--KHO--
	INSERT INTO Kho Values('11','Gà miếng',500)
	INSERT INTO Kho Values('12','Sandwich',200)
	INSERT INTO Kho Values('13','Nước ngọt',400)
	

end


SELECT * FROM Staff where Email='b'