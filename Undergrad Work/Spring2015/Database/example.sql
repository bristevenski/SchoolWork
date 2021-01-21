Drop table test1;
Drop table test2;

Create Table Test1 (
        C1   Char(5) Primary Key,
        C2   Varchar2(50),
        C3   Integer,
        C4   Date);

desc Test1;
pause;

Create Table Test2 (
        D1   VARCHAR2(15) Primary Key,
        D2   Char(5) references Test1,
        D3   Integer);

desc Test2;
pause;

commit;
