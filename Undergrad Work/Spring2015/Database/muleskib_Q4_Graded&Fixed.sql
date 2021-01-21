-- Grade 17/25 
-- FIXED
 
---------------------------------------------------------------------------------
-- Name       : Brianna Muleski
--
-- UserName   : muleskib
--
-- Course     : CS 3630
--
-- Section    : 2 (10 AM)
--              
-- Description: Quiz 4
--
-- Date       : May 1, 2015
--              Queries using joins and sub-queries
--              Views can be used but not required
---------------------------------------------------------------------------------

prompt
prompt Set column format 
Prompt 

col NIN format a8 heading "Staff No"
col FirstName format a11 heading "First Name"
col LastName format a10 heading "Last Name"
col Name format a15 heading "Hotel Name"
col HotelNo format a8 heading "Hotel No"
col city format a12 heading "City"
col State format a6 heading "State"
col hours format 999 heading "Hours"
col Payment format $9,999 heading "Salary"

prompt
prompt 1.
prompt For each pay roll record in ContractPayRoll, 
prompt list Hotel No, Hotel Name, payDate and payment,
prompt sorted on Hotel No in descending order,
prompt and then on payDate in ascending order.
prompt PayDate must be in the format Month dd yyyy, 
prompt e.g., May 01 2015 with heading "Pay Date"

select		H.HotelNo, Name, to_char(paydate, 'Mon dd yyyy') as "Pay Date", payment
from		AllHotels H
join		ContractPayRoll C
on			H.HotelNo = C.HotelNo
order by	H.HotelNo desc, payDate;

pause
prompt
prompt 2.
prompt For each hotel, 
prompt list Hotel No, Hotel Name, and the total number 
prompt of payments in ContractPayRoll by the hotel 
prompt with heading "Total # of Payments", 
prompt sorting on hotel no.
prompt A zero must be displayed if a hotel has no payments at all.
prompt

select		H.HotelNo, Name, count(C.HotelNo) as "Total # of Payments"
from		AllHotels H
left join	ContractPayRoll C
on			H.HotelNo = C.HotelNo
group by	H.HotelNo, Name
order by	H.HotelNo;

pause
prompt
prompt 3.
prompt For each staff who received payments
prompt from more than one hotel,
prompt list first name, last name and the number of 
prompt different hotels he/she received payments from
prompt with heading "# Hotels Worked on", 
prompt sorting on NIN.
prompt

-- Incorrect query: -2
-- FIXED (missed distinct)
 
select		firstName, lastName, count(unique C.HotelNo) as "# Hotels Worked On"
from		ContractPayRoll C
join		AllStaff S
on			C.NIN = S.NIN
group by	S.NIN, firstName, lastName
having		count(unique C.HotelNo) > 1
order by	S.NIN;

pause
prompt
prompt 4.  For each staff who received payments during the last month, 
prompt     list NIN and last name of the staff, hotel number
prompt     and name of each hotel the staff received payments from, and 
prompt     the total amount of payments the staff received last month from the hotel with  
prompt     heading "Total Amount of Payments", sorted on NIN and HotelNo.
prompt     The same query should work for any day.
prompt     

-- Incorrect query: -2 
-- FIXED (wrong date function, use sum not count)
 
select		S.NIN, lastName, H.HotelNo, Name, sum(payment) as "Total Amount of Payments"
from		AllStaff S
join		ContractPayRoll C
on			C.NIN = S.NIN
join		AllHotels H
on			H.HotelNo = C.HotelNo
where		to_char(payday, 'mm yyyy') = to_char(add_months(sysdate, -1), 'mm yyyy')
group by	S.NIN, firstName, lastName, H.HotelNo, Name
order by	S.NIN, H.HotelNo;

pause
prompt
prompt 5.  For each staff who did not receive any payments
prompt     during the last month, list NIN, last name, and 
prompt     the total number of payments the staff has received
prompt     with heading "No. of Payments", sorted by NIN. 
prompt     Dispaly a zero for staff without any payments.
prompt     The same query should work for any day.
prompt 

-- Incorrect query: -2 
-- FIXED (should use sub queries)
 
select		C.NIN, lastName, 
						(select count(*)
						 from	ContractPayRoll C
						 where 	S.NIN = C.NIN) as "No. of Payments"
 from		AllStaff S
 where		NIN not in
					(select C.NIN
					 from	ContractPayRoll C
					 where	C.NIN = S.NIN
					 and	to_char(add_months(sysdate, -1), 'mm yyyy') = to_char(paydate, 'mm yyyy'))
order by	S.NIN;



pause
prompt
prompt 6.  For each male staff from Platteville, WI, list NIN,
prompt     first name, last name and the total number of payments the staff
prompt     has received from all hotels with a rating of "*****". 
prompt     A zero should be displayed as the total number of payments for 
prompt     those specified staff without any specified payments.

-- Incorrect query: -2
-- FIXED (should use sub queries)
 
select		S.NIN, firstName, lastName, count(payment) as "# of Payments"
from		(select *
			 from	AllStaff
			 where	gender = 'M'
			 and	State = "WI"
			 and	City = "Platteville") S
left join	(select C1.*
			 from	ContractPayRoll C1
			 join	AllHotels H
			 on		H.HotelNo = C1.HotelNo
			 and	rating = '*****') C
on			C.NIN = S.NIN
group by	S.NIN, firstName, lastName
order by	S.NIN;


prompt Remove all column formatting
Clear col
