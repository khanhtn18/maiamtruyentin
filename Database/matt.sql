-- 1. Create Database
CREATE DATABASE MATT ON  PRIMARY 
	( NAME = 'MATT', 
	FILENAME = 'E:\Mái Ấm\data\MATT.mdf' , 
	SIZE = 3072KB ,
	MAXSIZE = UNLIMITED, 
	FILEGROWTH = 1024KB )
 LOG ON 
	( NAME = 'CharitySupportManagement_log', 
	FILENAME = 'E:\Mái Ấm\data\MATT_log.ldf' , 
	SIZE = 1024KB , 
	MAXSIZE = 2048KB , 
	FILEGROWTH = 10%)
GO
USE MATT
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create table Menu(
	ID	int identity,
	Date	datetime,
	Morning	nvarchar(250),
	BeforeNoon	nvarchar(250),
	Noon	nvarchar(250),
	LateAfterNoon	nvarchar(250),
	Evening	nvarchar(250),
	Description	nvarchar(250),
	CreatedDate	datetime default getdate(),
	CreatedBy	nvarchar(500),
	ModifiedDate	datetime default getdate(),
	ModifiedBy	nvarchar(500),
	Status	nvarchar(250),
	CONSTRAINT [PK_Menu] PRIMARY KEY (ID));
	go
create table Employee(
ID	Varchar(50),
IdentityCard	varchar(11),
Name	varchar(250),
Age	int,
Gender	nvarchar(250),
Image	nvarchar(250),
DateOfBirth	datetime,
Domicile	nvarchar(50),
PlaceOfBirth	nvarchar(250),
Education	nvarchar(50),
StudiedAt	nvarchar(250),
Language	nvarchar(250),
InformationTechnology	nvarchar(250),
Job	nvarchar(250),
JobName	nvarchar(250),
Phone	nvarchar(250),
Religion	nvarchar(250),
StartingSalagy	nvarchar(250),
GiftSalary	Decimal(11,0),
AllOtherFoodExpenses 	Decimal(11,0),
ContractType 	nvarchar(250),
WorkingContract	bit default 1,
WorkingDate 	datetime default getdate(),
StoppedWorkingDate 	datetime default getdate(),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Employee] PRIMARY KEY (ID));
	go
create table Children(
	ID	Varchar(50),
SocialInsurance	nvarchar(250),
BoughtDate 	datetime default getdate(),
EndDate 	datetime default getdate(),
FullName 	nvarchar(250),
Age 	nvarchar(250),
DateOfBirth	datetime ,
Gender 	nvarchar(250),
Image 	nvarchar(250),
BirthCertificate 	nvarchar(250),
Hk01	nvarchar(250),
Hk02	nvarchar(250),
FoodExpenses 	Decimal(11,0),
EducationExpenses 	Decimal(11,0),
Confirmation 	bit default 1,
EnrollReason 	nvarchar(250),
ChildrenCategoryID	varchar(50),
CouselingID	varchar(50),
SchoolReportID 	varchar(50),
XFamilyBookID	varchar(50),
EducationID 	varchar(50),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Children] PRIMARY KEY (ID));
	go
create table Volunteer(
ID	Varchar(50),
IdentityCard	varchar(11),
Name	varchar(250),
Age	nvarchar(500),
Gender	nvarchar(250),
Image	nvarchar(250),
Phone	varchar(11),
Email	Varchar(15) unique,
Nationality 	nvarchar(50),
Address 	nvarchar(250),
OtherFoodExpenses 	varchar(50),
WorkingHour 	datetime default getdate(),
OffHour 	datetime default getdate(),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_Volunteer] PRIMARY KEY (ID));
	go
create table XFamilyBook(
ID	Varchar(50),
ChildrenID	Varchar(50),
BaptismalName	Varchar(50),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_XFamilyBook] PRIMARY KEY (ID));
	go
create table Counseling(
ID	Varchar(50),
Problem	nvarchar(250),
Time	int,
Ticket 	nvarchar(250),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Counseling] PRIMARY KEY (ID));
	go
create table SchoolReport(
ChildrenID	Varchar(50),
SchoolYear	nvarchar(500),
SchoolName	nvarchar(250),
TeacherName	nvarchar(500),
Semester1	varchar(50),
Semester2	varchar(50),
FullYear	varchar(50),
Rating	nvarchar(250),
TeacherEvaluation	nvarchar(250),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_SchoolReport] PRIMARY KEY (ChildrenID));
	go
create table ChildrenCategory(
ID	Varchar(50),
Type 	nvarchar(250),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_ChildrenCategory] PRIMARY KEY (ID));
	go
create table Education(
ID	Varchar(50),
Name 	nvarchar(250),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Education] PRIMARY KEY (ID));
	go
create table Document(
ID	Varchar(50),
Example	nvarchar(50),
Description	nvarchar(250),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Document] PRIMARY KEY (ID));
	go
create table Cost(
ID	Varchar(50),
CostOfFacilitie	Decimal(10,0),
EmployeeSalary	Decimal(10,0),
ChildrenOfTuition	Decimal(10,0),
OtherCost	Decimal(10,0),
TotalCostAMonth	Decimal(10,0),
TotalCostPerYear	Decimal(10,0),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Cost] PRIMARY KEY (ID));
	go
create table OtherCosts(
ID	Varchar(50),
Name	nvarchar(max),
TotalAmount	Decimal(10,0),
DateOfPurchase	datetime,
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_OtherCosts] PRIMARY KEY (ID));
	go
create table SuppliesEquipment(
ID 	Varchar(50),
Number	int,
BrokenNumber	nvarchar(50),
Manager 	nvarchar(50),
NewPurchase	Decimal(10,0),
UsageHistory 	nvarchar(max),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_SuppliesEquipment] PRIMARY KEY (ID));
	go
create table Item(
ID	Varchar(50),
Name	nvarchar(250),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_Item] PRIMARY KEY (ID));
	go
create table Regulation(
ID 	Varchar(50),
Name 	nvarchar(50),
Description nvarchar(50),
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),

CONSTRAINT [PK_Regulation] PRIMARY KEY (ID));
	go
create table Visitor(
ID	int identity,
IdentityCard	varchar(11),
VisitReason 	Nvarchar(250),
Phone	Varchar(11),
Email	Varchar(25) unique,
CreatedDate	datetime default getdate(),
CreatedBy	nvarchar(500),
ModifiedDate	datetime default getdate(),
ModifiedBy	nvarchar(500),
Status	nvarchar(250),
CONSTRAINT [PK_Visitor] PRIMARY KEY (ID));
	go