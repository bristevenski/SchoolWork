            -- Grade: 17/10 

------------------------------------------------
-- Name        : Brianna Muleski
--
-- UserName    : muleskib
--
-- Date        : 4/17/2015
--
-- Course      : CS 3630
--               Section 2 (10 AM)
--
-- Assignment 9: Queries
------------------------------------------------
col Hotel_No format a8 heading 'Hotel No';
col Hotel_Name format a10 heading 'Hotel Name';
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

prompt;
prompt Assignment 9;
prompt;
prompt Name: Brianna Muleski;
prompt;

prompt 1.;
prompt List all rooms (all details) of hotel Glasgow,;
prompt sorted by hotel number and then price.;
prompt;

select		R.*
from		Room R
join		Hotel H
on			R.Hotel_No = H.Hotel_No
and			Name = 'Glasgow'
order by	R.Hotel_No, Price;

pause;

prompt;
prompt 2.;
prompt List all double or family rooms (all details);
prompt of hotel Glasgow with a price below 50 per night;
prompt sorted in ascending order of price.;
prompt;

select 		R.*
from		Room R
join		Hotel H
on			R.Hotel_No = H.Hotel_No
where		Name = 'Glasgow'
and			RType in ('Double', 'Family')
and			Price < 50
order by 	Price;

pause;

prompt;
prompt 3.;
prompt For each hotel that has at least 6 bookings,;
prompt list the hotel name, hotel number and the number;
prompt  of bookings, sorted by the number of bookings in 
prompt ascending order.;
prompt;

select		Name, H.Hotel_No, count(*) as "Number of Bookings"
from		Hotel H
join		Booking B
on			H.Hotel_No = B.Hotel_No
having		count(*) > 5
group by	H.Hotel_No, Name
order by	count(*);

pause;

prompt;
prompt 4.;
prompt For each hotel, list the hotel name, hotel number;
prompt and the number of bookings during the current month;
prompt of the current year. A zero should be displayed for;
prompt hotels that dont have any bookings during the current;
prompt month, and the query should work for any month of any year.;
prompt;

select		Name, H.Hotel_No, count(B.Hotel_No) as "Number of Bookings"
from		Hotel H
left join	Booking B
on			H.Hotel_No = B.Hotel_No
and			Date_From <= last_day(sysdate)
and			Date_To > last_day(add_months(sysdate, -1))
group by	H.Hotel_No, Name;

pause;

prompt;
prompt 5.;
prompt List all guests (all details) currently staying at hotel;
prompt Grosvenor in London, sorted on Guest_no. The query should;
prompt work for any day.;
prompt;

-- Incorrect query: -1
-- FIXED
 
select		distinct G.*
from		Guest G
join		Booking B
on			G.Guest_No = B.Guest_No
join		Hotel H
on			B.Hotel_No = H.Hotel_No
where		sysdate between Date_From and Date_To
and			H.Name = 'Grosvenor'
and			H.Address = 'London'
order by	G.Guest_No;

pause;

prompt;
prompt 6.;
prompt For each hotel that does not have any bookings, display;
prompt the hotel details, sorted on Hotel_No.;
prompt;

select		*
from		Hotel
where		Hotel_No not in
			(select	distinct Hotel_No
			 from	Booking)
order by	Hotel_No;

pause;

prompt;
prompt 7.;
prompt List the rooms (all details) that are currently unoccupied;
prompt at hotel Grosvenor in London. The query should produce correct;
prompt results today and any day in the future.;
prompt;

-- Incorrect query: -1 
-- FIXED
 
select		R.*
from		Room R
join		Hotel H
on			R.Hotel_No = H.Hotel_No
and			H.Name = 'Grosvenor'
and			H.Address = 'London'
and			(R.Hotel_No, R.Room_No) not in
			(select	B.Room_No, B.Hotel_No
			 from	Booking B
			 join	Hotel H1
			 on		B.Hotel_No = B.Hotel_No
			 and	sysdate between Date_From and Date_To);

pause;

prompt;
prompt 8.;
prompt For each hotel in London, list the hotel number, hotel name,;
prompt  and number of Family rooms with a price below 180. Display a;
prompt  zero for hotels in London that do not have specified rooms.;
prompt;

select		H.Hotel_No, Name, count(R.Room_No) as "Number of Rooms"
from		Hotel H
left join	Room R
on			H.Hotel_No = R.Hotel_No
and			RType = 'Family'
and			Price < 180
where		Address like '%London%'
group by	H.Hotel_No, Name;

pause;

prompt;
prompt 9.;
prompt List the guest number, guest name and the number of bookings;
prompt for the current year, sorted by guest_no. Display a zero for;
prompt guests who dont have any bookings for the current year. Your;
prompt query should work for any year. Booking could be longer than one year.;
prompt;

select		G.Guest_No, Guest_Name,
			(select count(*)
			 from 	Booking B
			 where 	G.Guest_No = B.Guest_No
			 and	to_char(Date_From, 'yyyy') <= to_char(sysdate, 'yyyy')
			 and	to_char(Date_To, 'yyyy') >= to_char(sysdate, 'yyyy')) as "Number of Bookings"
from		Guest G
group by	G.Guest_No, Guest_Name
order by	G.Guest_No;

pause;

prompt;
prompt 10.;
prompt For each hotel that has at least one booking, list the Hotel;
prompt number, Hotel name, and the most commonly booked room type for the;
prompt hotel (the number of bookings is the largest) with the count of;
prompt bookings for that room type. Notice that multiple types may have the;
prompt same largest number of bookings, and all such types should be listed.;
prompt;

-- Incorrect query: -1 
-- FIXED

create of replace view HotelBookings as
		(select R1.Hotel_No, Count(*) as numBookings
		 from	Room R1
		 join	Bookin B1
		 on R1.Hotel_No = B1.Hotel_No
		 and	R1.Room_No = B1.Room_No
		 group by R1.Hotel_No, R1.RType);
		 
select 		*
from		HotelBookings
order by	Hotel_No;

clear col;




