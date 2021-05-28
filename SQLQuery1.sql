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
	IDInforFood int PRIMARY KEY,
	IDFood int ,
	Name nvarchar(50),
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
	INSERT INTO Food Values('001','combo1',79000)
	INSERT INTO Food Values('002','combo2',79000)
	INSERT INTO Food Values('003','combo3',79000)
	INSERT INTO Food Values('101','Nước Ngọt',10000)
	INSERT INTO Food Values('201','Gà cay',20000)
	INSERT INTO Food Values('202','Gà không cay',20000)

	--InforFood--
	INSERT INTO InforFood Values('0001','001','Gà miếng','00001',2)
	INSERT INTO InforFood Values('0002','001','Nước ngọt','00003',1)

	INSERT INTO InforFood Values('0003','002','Gà miếng','00001',3)
	INSERT INTO InforFood Values('0004','002','Nước ngọt','00003',1)

	INSERT INTO InforFood Values('0005','003','Gà miếng','00001',2)
	INSERT INTO InforFood Values('0006','003','Nước ngọt','00003',2)
	INSERT INTO InforFood Values('0007','003','Sandwich','00002',1)

	INSERT INTO InforFood Values('0008','101','Nước ngọt','00003',1)

	INSERT INTO InforFood Values('0009','201','Gà miếng','00001',1)

	INSERT INTO InforFood Values('0010','202','Gà miếng','00001',1)

	--KHO--
	INSERT INTO Kho Values('00001','Gà miếng',200)
	INSERT INTO Kho Values('00002','Sandwich',30)
	INSERT INTO Kho Values('00003','Nước ngọt',100)

end


