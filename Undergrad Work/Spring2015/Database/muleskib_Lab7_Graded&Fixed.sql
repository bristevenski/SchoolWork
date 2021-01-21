
-- Grade: 10/10

------------------------------------------------
-- Name       : Brianna Muleski
-- UserName   : muleskib
-- Date       : 03-25-15
-- Course     : CS 3630
-- Description: Drop tables
--              Create tables
--              Insert records
------------------------------------------------
drop table Booking;
drop table Room;
drop table Guest;
drop table Hotel;


create table Hotel (
	Hotel_No	char(3) 		primary key,
	Name		varchar2(15)	not null,
	Address		varchar2(30)	not null);
		
desc Hotel;

create table Room (
	Room_No		char(4),
	Hotel_No	char(3) 		references Hotel,
	RType		char(6) 		default 'Double' not null check (RType in ('Single', 'Double', 'Family')),
	Price		number	 		not null check (Price between 30 and 200),
	constraint PK_Room
		primary key (Hotel_No, Room_No));
		
desc Room;

create table Guest (
	Guest_No	char(6) 		primary key,
	Guest_Name	varchar2(30) 	not null,
	Address		varchar2(40));

desc Guest;

create table Booking (
	Hotel_No	char(3),
	Guest_No	char(6)			not null,
	Date_From	date,
	Date_To		date			not null,
	Room_No		char(4),
	constraint PK_Booking
		primary key (Hotel_No, Room_No, Date_From),
	foreign key (Hotel_No, Room_No) references Room,
	foreign key (Guest_No) references Guest);
		
desc Booking;
pause;

insert into Hotel
values ('H01', 'Grosvenor', 'London');

insert into Hotel
values ('H05', 'Glasgow', 'London');

insert into Hotel
values ('H07', 'Aberdeen', 'London');

insert into Hotel
values ('H12', 'London', 'Glasgow');

insert into Hotel
values ('H16', 'Aberdeen', 'Glasgow');

insert into Hotel
values ('H24', 'London', 'Aberdeen');

insert into Hotel
values ('H28', 'Glasgow', 'Aberdeen');

insert into Room
values ('R001', 'H01', 'Single', 30);

insert into Room
values ('R002', 'H01', 'Single', 100);

insert into Room
values ('R103', 'H01', 'Double', 30);

insert into Room
values ('R105', 'H01', 'Double', 119);

insert into Room
values ('R209', 'H01', 'Family', 150);

insert into Room
values ('R219', 'H01', 'Family', 190);

insert into Room
values ('R001', 'H05', 'Double', 39);

insert into Room
values ('R003', 'H05', 'Single', 40);

insert into Room
values ('R103', 'H05', 'Single', 55);

insert into Room
values ('R101', 'H05', 'Double', 40);

insert into Room
values ('R104', 'H05', 'Double', 105);

insert into Room
values ('R105', 'H12', 'Double', 45);

insert into Room
values ('R201', 'H12', 'Family', 80);

insert into Room
values ('R003', 'H28', 'Family', 49.95);

insert into Guest
values ('G01003', 'John White', '6 Lawrence Street, Glasgow');

insert into Guest
values ('G01011', 'Mary Tregear', '5 Tarbot Rd, Aberdeen');

insert into Guest
values ('G02003', 'Aline Stewart', '64 Fern Dr, London');

insert into Guest
values ('G02005', 'Mike Ritchie', '18 Tain St, London, W1H 7DL, England');

insert into Guest
values ('G02007', 'Joe Keogh', null);

insert into Guest
values ('G12345', 'CS 3630', 'London');

insert into Guest
values ('G02008', 'Scott Summers', 'London W1H 7DL, England');

insert into Booking
values ('H01', 'G01003', '25-Apr-04', '14-May-04', 'R001');

insert into Booking
values ('H01', 'G02003', '24-Apr-04', '26-Apr-04', 'R103');

insert into Booking
values ('H01', 'G01011', '25-Apr-04', '30-Apr-04', 'R209');

insert into Booking
values ('H05', 'G01003', '05-May-05', '14-May-05', 'R003');

insert into Booking
values ('H05', 'G02003', '12-Mar-05', '15-May-05', 'R003');

insert into Booking
values ('H01', 'G01011', '11-Mar-05', '30-Apr-05', 'R103');

insert into Booking
values ('H01', 'G02007', '11-Apr-05', '02-Sep-05', 'R001');

insert into Booking
values ('H28', 'G01003', '01-Jan-10', '10-Jan-10', 'R003');

insert into Booking
values ('H05', 'G02003', '12-Mar-15', '15-May-15', 'R003');

insert into Booking
values ('H01', 'G01011', '11-Mar-15', '30-Apr-15', 'R103');

insert into Booking
values ('H01', 'G02007', '11-Apr-15', '02-Sep-15', 'R001');

insert into Booking
values ('H01', 'G02007', '11-Jan-15', '22-Jan-15', 'R001');

insert into Booking
values ('H01', 'G02003', '11-Dec-12', '22-Jan-16', 'R209');

commit;

		