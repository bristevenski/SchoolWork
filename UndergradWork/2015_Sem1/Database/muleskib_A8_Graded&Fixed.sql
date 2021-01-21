
-- Grade: 9.5/10

------------------------------------------------
-- Name        : Brianna Muleski
--
-- UserName    : muleskib
--
-- Date        : 3/31/2015
--
-- Course      : CS 3630
--               Section 2 (10 AM)
--
-- Assignment 8: Queries
------------------------------------------------
col Hotel_No format a8 heading 'Hotel No';
col Room_No format a7 heading 'Room No';
col RType format a9 heading 'Room Type';
col Guest_Name format a30 heading 'Guest Name';
col Guest_No format a8 heading 'Guest No';
col Date_From format a21 heading 'Date From';
col Date_To format a21 heading 'Date To';
col Price format $999.99 heading 'Price/Night';
col avg(Price) format $999.99 heading 'Average Price';
col max(Price) format $999.99 heading 'Highest Price';
col min(Price) format $999.99 heading 'Lowest Price';
col count(*) heading 'Room Count';

prompt;
prompt Assignment 8;
prompt;
prompt Name: Brianna Muleski;
prompt;

prompt 1.;
prompt  List the names and addresses of all guests from London;
prompt (Address contains string "London") sorted by name in ascending order.;
prompt;

select 	Guest_Name, Address
from	Guest
where	Address like '%London%'
order	by Guest_Name;

pause;

prompt;
prompt 2.;
prompt List all guests whose address is missing.;
prompt;

select 	*
from	Guest
where	Address is null;

pause;

prompt;
prompt 3.;
prompt List all double or family rooms with a price below 40 per night sorted in;
prompt ascending order of price.;
prompt;

select	*
from	Room
where	RType = 'Double'
and		Price < 40
or		RType = 'Family'
and		Price < 40;

pause;

prompt;
prompt 4.;
prompt For each room type, list the type and the average price, sorted by the average;
prompt price in descending order.;
prompt;

select 	RType, avg(Price)
from	Room
group	by RType
order	by avg(Price) desc;

pause;

prompt;
prompt 5.;
prompt List the number of different guests who have bookings during April 2005.;
prompt;

select	count(unique Guest_No) as "Number of Different Guests"
from	Booking
where	not Date_From > '30-Apr-05'
and		not Date_To < '1-Apr-05';

pause;

prompt;
prompt 6.;
prompt  For each guest who has made at least one booking, list the guest number and;
prompt the total number of bookings the guest has made, sorted by guest number.;
prompt;

select	Guest_No, count(*)
from	Booking
group	by Guest_No
having	count(*) > 1
order	by Guest_No;

pause;

prompt;
prompt 7.;
prompt For each hotel that has at least one booking during April 2005, list the;
prompt hotel number, the total number of bookings the hotel has for April 2005 and the;
prompt latest Date_from for such bookings, sorted by the total number of bookings.;
prompt;

select 	Hotel_No, count(*), to_char(max(Date_From), 'Month dd yyyy') as "Latest Date From"
from	Booking
where	not Date_From > '30-Apr-05'
and		not Date_To < '1-Apr-05'
group	by Hotel_No
having	count(*) > 0
order	by count(*);

pause;

prompt;
prompt 8.;
prompt List all bookings that start in the current month of the current year. The query;
prompt should work for any month of any year without modification.;
prompt;

-- Incorrect formatting: -0.5

select	*
from	Booking
where	to_char(Date_From, 'yyyy') = to_char(sysdate, 'yyyy')
and		to_char(Date_From, 'mm') = to_char(sysdate,'mm');

pause;

prompt;
prompt 9.;
prompt For each room type of each hotel, list the hotel number and room type with the;
prompt highest and the lowest room prices. Sort the result by hotel number and then;
prompt  room type.;
prompt;

select 	Hotel_No, RType, min(Price), max(Price)
from	Room
group	by RType, Hotel_No
order	by Hotel_No, RType;

pause;

prompt;
prompt 10.;
prompt For each room type of each hotel, list the hotel number and room type with the;
prompt highest and the lowest room prices, if the highest price is at least 100 or the; 
prompt lowest price is at most 30, sorted by hotel_no and the highest price.;
prompt;

select 	Hotel_No, RType, min(Price), max(Price)
from	Room
group	by RType, Hotel_No
having	max(Price) > 99
or		min(Price) < 31
order	by Hotel_No, max(Price);

clear col;