

select * from tblLogin


create table Projects
(
	ProjectId int identity(1001,1) primary key,
	ProjectName varchar(30),
	CompanyName varchar(30),
	Id int references tblLogin(Id)

)

insert into Projects values ('5G','Airtel',2)

 
 select * from Projects



create table TimeSheetDetails
(
	TimeSheetId int identity primary key,
	DaysOfWeek varchar(30),
	hours int ,
	ProjectId int references Projects(ProjectId),
	Id int references tblLogin(Id)
)

