using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    public class EmployeePayroll
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string BasicPay { get; set; }
        public string Deductions { get; set; }
        public string TaxablePay { get; set; }
        public string Tax { get; set; }

        public string NetPay { get; set; }
        public string StartDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
    }
}
