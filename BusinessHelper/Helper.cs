using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManagement.BusinessHelper
{
    public class Helper
    {
        public List<Designation_Master> Get_Designations()
        {
            //here we can get data from database table of designation
            List<Designation_Master> designations = new List<Designation_Master>();
            designations.Add(new Designation_Master()
            {
                Designation_Id = 1,
                Designation = "Software Engineer"
            });
            designations.Add(new Designation_Master()
            {
                Designation_Id = 2,
                Designation = "Senior Software Engineer"
            });
            designations.Add(new Designation_Master()
            {
                Designation_Id = 3,
                Designation = "Software Tester"
            });
            designations.Add(new Designation_Master()
            {
                Designation_Id = 4,
                Designation = "Manager"
            });
            designations.Add(new Designation_Master()
            {
                Designation_Id = 5,
                Designation = "Database Administrator"
            });
            return designations;
        }
    }
}