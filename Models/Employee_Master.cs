using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeeManagement.Models
{
    public class Employee_Master
    {
        [Display(Name = "Employee ID")]
        public long Employee_Id { get; set; }

        [Required(ErrorMessage = "Please enter First name.")]
        [Display(Name = "First Name")]
        public string Employee_First_name { get; set; }
        [Required(ErrorMessage = "Please enter  Employee Middle name.")]
        [Display(Name = "Middle Name")]
        public string Employee_Middle_name { get; set; }
        [Required(ErrorMessage = "Please enter Employee Last Name.")]
        [Display(Name = "Last Name")]
        public string Employee_Last_Name { get; set; }
        [Required(ErrorMessage = "Please enter Date of birth.")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Display(Name = "Designation")]
        [Required(ErrorMessage = "Please enter Designation")]
        public int Designation_Id { get; set; }
        [NotMapped]
        public string Designation { get; set; }
        [Display(Name = "Address")]
        public string Employee_Address { get; set; }
        [Display(Name = "Address same as Company")]
        public bool Address_Same_As_Company { get; set; }
        [Required(ErrorMessage = "Please Enter City Name.")]
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Category")]
        public string Employee_category { get; set; }
        [Display(Name = "Salary")]
        public decimal Employee_Salary { get; set; }
    }   
}