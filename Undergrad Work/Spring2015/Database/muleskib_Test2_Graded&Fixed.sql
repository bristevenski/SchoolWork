
--   Grade: 54/60 
 

------------------------------------------------
-- Name    : Brianna Muleski
--
-- UserName: muleskib
--
-- Date    : May-06-2015
--
-- Course  : CS 3630
--           Test 2 (60 points)
--
-- Section : 2 (10 AM)
--         
------------------------------------------------

set pagesize 20

col NIN format a8 heading "Staff No"
col DOB format a12 heading "Birth Day"
col FirstName format a11 heading "First Name"
col LastName format a10 heading "Last Name"
col State format a6 heading "State"
col Name format a15 heading "Hotel Name"
col HotelNo format a8 heading "Hotel No"
col city format a12 heading "City"
col hours format 999 heading "Hours"
col PayDate heading "Pay Date"
col "Total Amount of Payments" format $9,999 
col Payment format $9,999 heading "Payment"
col Average format $9,999.00 heading "Average"
col "Amount of Payments" format $9,999 
col "Largest Payment"  format $9,999 
col "Smallest Payment"  format $9,999 

Prompt
Prompt 1.  List NIN, FirstName, LastName and DOB of all staff whose birth day 
Prompt     is between June 21 1955 and June 26 1965, inclusive, sorted on DOB
Prompt     in ascending order and then on LastName in descending order
Prompt

select		NIN, firstName, lastName, DOB
from		AllStaff S
where		DOB < to_date('27-Jun-1965')
and			DOB > to_date('20-Jun-1955')
order by	DOB, lastName desc;

pause
Prompt
Prompt 2.  For each hotel that has made more than three payments, 
Prompt     list the HotelNo, total number of payments by the hotel
Prompt     and the average payment of all payments by the Hotel,
Prompt     sorted by hotel number. 
Prompt     The heading must be "Count" and "Average".
Prompt

-- Incorrect query: -3
-- FIXED 
 
select		H.HotelNo, count(*) as "Count", avg(payment) as "Average"
from		ContractPayRoll C
group by	H.HotelNo
having		count(*) > 3
order by	H.HotelNo;

pause
prompt
prompt 3.
prompt For each pay roll record in ContractPayRoll, 
prompt list the FirstName, LastName, payDate and payment,
prompt sorted on NIN in descending order,
prompt and then on payDate in ascending order.
prompt PayDate must be in the format Month dd yyyy, 
prompt e.g., May 01 2015 with heading "Pay Date"

select		firstName, lastName, to_char(payDate, 'Month dd yyyy') as "Pay Date", payment
from		ContractPayRoll C
join		AllStaff S 
on			S.NIN = C.NIN
order by	C.NIN desc, payDate;

pause
Prompt
Prompt 4.  Retrieve NIN, FirstName and LastName of all staff 
Prompt     who have not received any payments in the current 
Prompt     month, sorted by NIN.
prompt     The same query should work at any time.
prompt 

select		S.NIN, firstName, lastName
from		AllStaff S
where		NIN not in
				(select	C.NIN
				 from	ContractPayRoll C
				 where 	C.NIN = S.NIN
				 and	to_char(sysdate, 'mm yyyy') = to_char(payDate, 'mm yyyy'))
order by	S.NIN;

               
pause
Prompt
Prompt 5. For each staff, list FirstName, LastName and the number of 
Prompt    payments the staff has received from all hotels with heading 
Prompt    "Number of Payments", sorted by NIN.
Prompt    For a staff member without payments, a zero should be displayed. 
Prompt

select		firstName, lastName, count(C.NIN) as "Number of Payments"
from		AllStaff S 
left join	ContractPayRoll C 
on			S.NIN = C.NIN 
group by	S.NIN, firstName, lastName
order by	S.NIN;

pause 
Prompt
Prompt 6. For each staff who has received payments in the current month, 
Prompt    list FirstName, LastName, total number of payments (with 
Prompt    heding "Number of Payments") and the total amount of payments 
Prompt    (with heading "Amount of Payments") the staff has received 
Prompt    in the current month, sorted by the total amount of payments 
Prompt    then on NIN.

-- Incorrect query: -3 
-- FIXED
 
select		firstName, lastName,
						(select	count(*)
						 from	ContractPayRoll C
						 where	S.NIN = C.NIN) as "Number of Payments",
						(select sum(payment)
						 from	ContractPayRoll C1
						 where	S.NIN = C.NIN) as "Amount of Payments"
from		AllStaff S 
where		NIN in
				(select	C.NIN
				 from	ContractPayRoll C 
				 where	C.NIN = S.NIN
				 and	to_char(sysdate, 'mm yyyy') = to_char(payDate, 'mm yyyy'))	
order by	"Amount of Payments", S.NIN;



pause 
Prompt
Prompt 7. For each staff who has received at least two payments, 
Prompt    but did not received any payments during the last month, 
Prompt    list FirstName, LastName, the largest payment amount 
Prompt    with heading "Largest Payment" and the smallest payment
Prompt    amount with heading "Smallest Payment" the staff has received.
Prompt

select		firstName, lastName, 
					(select	max(payment)
					 from	ContractPayRoll C 
					 where	S.NIN = C.NIN) as "Largest Payment", 
					(select	min(payment) 
					 from	ContractPayRoll C 
					 where	S.NIN = C.NIN) as "Smallest Payment"
from		AllStaff S
where		NIN not in
				(select	C.NIN
				 from	ContractPayRoll C 
				 where	C.NIN = S.NIN
				 and	to_char(add_months(sysdate, -1), 'mm yyyy') = to_char(payDate, 'mm yyyy'))
and			NIN in
				(select	C.NIN
				 from	ContractPayRoll C 
				 where	C.NIN = S.NIN
				 group by C.NIN
				 having	count(*) > 1);


pause 
Prompt
Prompt 8. For each male staff, list FirstName, LastName and the number of payments
Prompt    the staff has received from hotels in Platteville, WI, sorted by NIN.
Prompt    Using heading "Number of Payments" for the count. 
Prompt    For a staff member who has no such payments, a zero should be displayed. 
Prompt

select		firstName, lastName, count(payment) as "Number of Payments"
from		(select *
			 from	AllStaff
			 where	gender = 'M') S
left join	(select C1.*
			 from	ContractPayRoll C1
			 join	AllHotels H 
			 on		H.HotelNo = C1.HotelNo
			 and	H.state = 'WI'
			 and	H.city = 'Platteville') C
on			C.NIN = S.NIN
group by	S.NIN, firstName, lastName
order by	S.NIN;
					
Prompt 
Prompt Remove column formatting
Prompt 

clear col 
