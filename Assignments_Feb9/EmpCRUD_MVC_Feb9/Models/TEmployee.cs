using System;
using System.Collections.Generic;

namespace EmpCRUD_MVC_Feb9.Models
{
    public partial class TEmployee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeAge { get; set; }
        public int? EmployeeSalary { get; set; }
        public string? EmployeeDesignation { get; set; }
        public string? EmployeeAddress { get; set; }
    }
}
