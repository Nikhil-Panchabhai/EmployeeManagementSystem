using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Employee_Attendance
    {        
        [Display(Name = "Attendance Id")]
        public long Attendance_Id { get; set; }

        public long Employee_Id { get; set; }
        [NotMapped]
        [Display(Name="Employee Name")]
        public string Employee_name { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Attenadance")]
        public string Attenedance_Status { get; set; }
    }
}