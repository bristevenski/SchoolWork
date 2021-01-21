
			-- Grade: 23/25
			
---------------------------------------------------------------------------------
-- Name       : Brianna Muleski
--
-- UserName   : muleskib
--
-- Course     : CS 3630
--
-- Section    : 10 AM
--
-- Description: Quiz 3
--
-- Date       : April 15, 2015
---------------------------------------------------------------------------------

prompt
prompt 1. Set column format 
Prompt 

-- Column NIN is displayed as string of length 8 with heading "Staff No"
-- Column DOB is displayed as string of length 12 with heading "Birth Day"
-- Column FirstName is displayed as string of length 10 with heading "First Name"
-- Column LastName is displayed as string of length 10 with heading "Last Name"
-- Column StaffNo is displayed as string of length 8 with heading "Staff No"
-- Column State is displayed as string of length 6 with heading "State"
-- Column HotelNo is displayed as string of length 8 with heading "Hotel No"

col NIN format a8 heading 'Staff No';
col DOB format a12;
col FirstName format a10 heading 'First Name';
col LastName format a10 heading 'Last Name';
col StaffNo format a8 heading 'Staff No';
col State format a6 heading 'State';
col HotelNo format a8 heading 'Hotel No';

pause
prompt
prompt 2.
prompt List NIN, FirstName, LastName and DOB of all 
prompt staff, sorted on DOB in descending order,
prompt and then on last name in ascending order.
prompt DOB must be in the format mm/dd/yyyy, e.g., 06/21/1955.
prompt

select 	NIN, FirstName, LastName, to_char(DOB, 'mm/dd/yyyy') "Birth Day"
from	AllStaff
order	by DOB desc, LastName;

pause
prompt
prompt 3.
prompt List NIN, firstName and lastName of all staff
prompt whose DOB is missing or 
prompt the fourth char of the last name is a lower case n.
prompt 

select 	NIN, FirstName, LastName
from	AllStaff
where	DOB is null
or		LastName like '___n%';


pause
prompt
prompt 4.
prompt For each staff and each hotel, list NIN, HotelNo,
prompt and the total number of hours (with heading "Total Hours")
prompt the staff has worked for the hotel,
prompt sorted by NIN and then HotelNo.
prompt

-- Sample output
-- 1001   H18001   20 
-- 1001   H19001   32
-- 1001   H19005   44 
-- 1001   H19008   99 
-- 2001   H18001   50 
-- 2001   H19001   92

select	NIN, HotelNo, sum(Hours) as "Total Hours"
from	ContractPayRoll
group	by NIN, HotelNo
order	by NIN, HotelNo;


pause
prompt
prompt 5.
prompt For each staff who has been paid between April 04, 2015 
prompt and April 11, 2015 (inclusive), list the NIN and the 
prompt total number of hours (with heading "Total Hours") the 
prompt staff has been paid during that period of time.
prompt

select	NIN, sum(Hours) as "Total Hours"
from	ContractPayRoll
where	paydate > '03-Apr-15'
and		paydate < '12-Apr-15'
group	by NIN;



pause
prompt
prompt 6.
prompt For each city of each state that has more than one staff, list
prompt the City, State, and the total number of staff from the city
prompt (with heading "Number of Staff").
prompt 

select	City, State, count(*) as "Number of Staff"
from	AllStaff
group	by City, State
having	count(*) > 1;

pause
prompt
prompt 7.
prompt For each staff who has been paid at least 40 hours
prompt in the current month of the current year, 
prompt list the NIN and the number of hours with heading "Total Hours" 
prompt the staff has in the current month of the current year.
prompt The same query should work for any month 
prompt of any year without being modified.
prompt

-- Incorrect Query: -2

select	NIN, sum(Hours) as "Total Hours"
from	ContractPayRoll
where	Hours > 39
and		to_char(paydate, 'yyyy') = to_char(sysdate, 'yyyy')
and		to_char(paydate, 'mm') = to_char(sysdate, 'mm')
group	by NIN;

pause
prompt 
Prompt 8. Remove all column formatting
prompt 

clear col;

