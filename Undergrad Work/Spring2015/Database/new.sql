------------------------------------------------
-- Name    : Brianna Muleski
--
-- UserName: muleskib
--
-- Date    : May-14-2015
--
-- Course  : CS 3630
--           Part II of Final Exam (60 points)
--
-- Section : 2 (10 AM)
--           
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
col Payment format $9,999 heading "Payment"
col "Amount of Payments" format $9,999 
col "Largest Payment"  format $9,999 
col "Smallest Payment"  format $9,999 
col "Average" format $9,999.00  
col "Total" format $9,999 
col ContractNo format a16 heading "Contract number"


Prompt
Prompt 1.  List NIN, ContractNo, HotelNo and PayDate of all pay roll records
Prompt     between April 1 2014 and March 11 2015, inclusive, sorted on payDate
Prompt     in ascending order and then on NIN in descending order
Prompt

select		NIN, ContractNo, HotelNo, PayDate
from		ContractPayRoll
where		payDate <= '11-Mar-15'
and			payDate >= '1-Apr-14'
order by	payDate, NIN desc;

pause
Prompt
Prompt 2.  For each staff who has received more than three payments, 
Prompt     list NIN, total number of payments received by the staff
Prompt     and the average payment of all payments received by the staff,
Prompt     sorted by NIN. 
Prompt     The heading must be "# of Payments" and "Average".
Prompt

select		NIN, count(*) as "# of Payments", avg(payment) as "Average"
from		ContractPayRoll
group by	NIN
having		count(*) > 3
order by	NIN;

pause
prompt
prompt 3.
prompt For each pay roll record in ContractPayRoll, 
prompt list the HotelNo, hotel name, payDate and payment,
prompt sorted on payDate in descending order,
prompt and then on HotelNo in ascending order.
prompt PayDate must be in the format dd Month yyyy, 
prompt e.g., 01 May 2015 with heading "Pay Date"

select		H.HotelNo, Name, to_char(payDate, 'dd month yyyy') as "Pay Date", payment
from		AllHotels H
join		ContractPayRoll C
on			H.HotelNo = C.HotelNo
order by	payDate desc, H.HotelNo;

pause
Prompt
Prompt 4.  Retrieve hotel number, name, city and state of all
Prompt     hotels that did not give any payments in the 
Prompt     previous month, sorted by HotelNo.
prompt     The same query should work at any time.
prompt 

select		H.HotelNo, Name, City, State
from		AllHotels H
where		H.HotelNo not in
			(select C.HotelNo
			 from	ContractPayRoll C 
			 where	C.HotelNo = H.HotelNo
			 and	to_char(add_months(sysdate, -1),'mm yyyy') = to_char(payDate, 'mm yyyy'))
order by	H.HotelNo;
               
pause
Prompt
Prompt 5. For each hotel, list hotel name, city, state and and the number
Prompt    of payments the hotel has given for all staff with heading 
Prompt    "Number of Payments", sorted by HotelNo.
Prompt    For a hotel without any payments, a zero should be displayed. 
Prompt

select		Name, City, State, 
						(select count(*)
						 from	ContractPayRoll C
						 where	H.HotelNo = C.HotelNo) as "Number of Payments"
from		AllHotels H
order by	H.HotelNo;

pause 
Prompt
Prompt 6. For each hotel that gave any payments in the previous month, 
Prompt    list hotel number, city, state and total number of payments (with 
Prompt    heding "Count") and the total amount of payments 
Prompt    (with heading "Total") the hotel gave
Prompt    in the previous month, sorted by the count
Prompt    then on HotelNo.

select		H.HotelNo, City, State, count(C.HotelNo) as "Count", sum(payment) as "Total"
from		AllHotels H
join		ContractPayRoll C 
on			C.HotelNo = H.HotelNo
where		to_char(add_months(sysdate, -1),'mm yyyy') = to_char(payDate, 'mm yyyy')
group by	H.HotelNo, City, State
order by	"Count", H.HotelNo;	

pause 
Prompt
Prompt 7. For each hotel that has given at least two payments, 
Prompt    but has not given any payments during this month, 
Prompt    list the hotel name, city, state, the average payment amount 
Prompt    with heading "Average" by the hotel, 
Prompt    sorted by hotel number in descending order.

select		Name, City, State, 
					(select	avg(payment)
					 from	ContractPayRoll C 
					 where	C.HotelNo = H.HotelNo) as "Average"
from		AllHotels H 
where		H.HotelNo not in
				(select	C.HotelNo
				 from	ContractPayRoll C 
				 where	C.HotelNo = H.HotelNo
				 and	to_char(payDate, 'mm yyyy') = to_char(sysdate, 'mm yyyy'))
and			H.HotelNo in
				(select 	C.HotelNo
				 from		ContractPayRoll C 
				 where		C.HotelNo = H.HotelNo
				 group by	C.HotelNo
				 having		count(*) > 1)
order by	H.HotelNo desc;

pause 
Prompt
Prompt 8. For each hotel in Platteville, WI, 
Prompt       that has given no more than three payments 
Prompt       to male staff who were born before 1965, 
Prompt    list HotelNo, Name and the number of payments 
Prompt    with heading "Count" the hotel has given to
Prompt    male staff who were born before 1965, 
Prompt    sorted by hotel number. 
Prompt    For a hotel that has no such payments, 
Prompt       a zero should be displayed. 
Prompt

create or replace view PlattHotelPayments as
	(select	H.HotelNo, Name, payment, NIN
	 from	AllHotels H 
	 join	ContractPayRoll C
	 on		H.HotelNo = C.HotelNo
	 where	H.state = 'WI'
	 and	H.city = 'Platteville');
	 

select		H.HotelNo, Name, count(payment) as "Count"
from		(select	*
			 from	AllStaff
			 where	gender = 'M'
			 and	to_char(DOB, 'yyyy') < 1965) S
left join	(select *
			 from	PlattHotelPayments) H
on			H.NIN = S.NIN
group by	H.HotelNo, Name
having		count(payment) <= 3
order by	H.HotelNo;

Prompt 
Prompt Remove column formatting
Prompt 

clear col 
