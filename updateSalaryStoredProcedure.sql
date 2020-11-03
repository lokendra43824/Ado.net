USE [PayRollAssignment]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateSalary]    Script Date: 04-11-2020 00:04:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[spUpdateSalary]
@address varchar(30),
@name varchar(30)
as
begin
  update Employee_payroll set address = @address where id=(select id from Employee_payroll where name=@name);
end 