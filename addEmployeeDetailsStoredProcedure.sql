create procedure spAddEmployeeDetails
  @EmpName varchar(100),
  @StartDate date,
  @Gender varchar(1),
  @Address varchar(100),
  @phoneNumber varchar(20)

as 
begin
  insert into Employee_payroll(name,start_Date,Gender,address,phoneNumber) values(@EmpName,@StartDate,@Gender,@Address,@phoneNumber)
end