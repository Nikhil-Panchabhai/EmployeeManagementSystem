using EmployeeManagement.BusinessHelper;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Emplyee
        public ActionResult List()
        {
            List<Employee_Master> employee_list = new List<Employee_Master>();
            employee_list = Session["EmployeeMaster"] is null?null:(List<Employee_Master>)Session["EmployeeMaster"];
            return View(employee_list);
        }
        public ActionResult Register()
        {
            List<Designation_Master> designations = new List<Designation_Master>();
            Helper helper = new Helper();
            designations=helper.Get_Designations();
            List<SelectListItem> ddl_designation = new List<SelectListItem>();
            foreach(Designation_Master designation in designations)
            {
                ddl_designation.Add(new SelectListItem()
                {
                    Value = designation.Designation_Id.ToString(),
                    Text = designation.Designation
                });
            }
            ViewBag.ddl_designation = ddl_designation;
            return View();
        }
        [HttpPost]
        public ActionResult Register(Employee_Master employee)
        {
            if(ModelState.IsValid)
            {
                List<Employee_Master> employee_list = new List<Employee_Master>();
                List<Designation_Master> designations = new List<Designation_Master>();
                Helper _helper = new Helper();
                employee_list = Session["EmployeeMaster"] is null ? new List<Employee_Master>() : (List<Employee_Master>)Session["EmployeeMaster"];
                if (employee_list.Count > 0)
                    employee.Employee_Id = employee_list.Count + 1;
                else
                    employee.Employee_Id = 1;


                designations = _helper.Get_Designations();
                List<SelectListItem> ddl_designation = new List<SelectListItem>();
                foreach (Designation_Master designation in designations)
                {
                    ddl_designation.Add(new SelectListItem()
                    {
                        Value = designation.Designation_Id.ToString(),
                        Text = designation.Designation
                    });
                }
                ViewBag.ddl_designation = ddl_designation;

                employee.Designation = designations.Where(m => m.Designation_Id == employee.Designation_Id).Select(m => m.Designation).FirstOrDefault();


                employee_list.Add(employee);
                Session["EmployeeMaster"] = employee_list;
                ViewBag.Message = "Employee data submitted successfully.";
                
            }
            else
            {
                ViewBag.Message = "Please enter correct data.";
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult Edit(long Employee_Id)
        {
            Employee_Master employee = new Employee_Master();
            if (Employee_Id != 0)
            {
                List<Employee_Master> employee_list = new List<Employee_Master>();
                List<Designation_Master> designations = new List<Designation_Master>();
                Helper _helper = new Helper();
                employee_list = Session["EmployeeMaster"] is null ? new List<Employee_Master>() : (List<Employee_Master>)Session["EmployeeMaster"];
                if (employee_list != null && employee_list.Count > 0)
                {
                    employee = employee_list.Where(m => m.Employee_Id == Employee_Id).FirstOrDefault();
                }

                designations = _helper.Get_Designations();
                List<SelectListItem> ddl_designation = new List<SelectListItem>();
                foreach (Designation_Master designation in designations)
                {
                    ddl_designation.Add(new SelectListItem()
                    {
                        Value = designation.Designation_Id.ToString(),
                        Text = designation.Designation
                    });
                }
                ViewBag.ddl_designation = ddl_designation;
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee_Master Employee)
        {
            Employee_Master employee = new Employee_Master();
            if (Employee != null)
            {
                List<Employee_Master> employee_list = new List<Employee_Master>();
                List<Designation_Master> designations = new List<Designation_Master>();
                Helper _helper = new Helper();
                employee_list = Session["EmployeeMaster"] is null ? new List<Employee_Master>() : (List<Employee_Master>)Session["EmployeeMaster"];
                
                employee_list.Where(S => S.Employee_Id == Employee.Employee_Id)
                                .Select(S => { S.Employee_First_name = Employee.Employee_First_name; 
                                    S.Employee_First_name = Employee.Employee_First_name;
                                    S.Employee_Last_Name = Employee.Employee_Last_Name;
                                    S.Employee_Middle_name = Employee.Employee_Middle_name; 
                                    S.DOB = Employee.DOB; 
                                    S.Employee_Address = Employee.Employee_Address; 
                                    S.Employee_category = Employee.Employee_category;
                                    S.Employee_Salary = Employee.Employee_Salary; 
                                    S.Address_Same_As_Company = Employee.Address_Same_As_Company; 
                                    S.City = Employee.City; 
                                    S.Designation_Id = Employee.Designation_Id;
                                    return S; }).ToList();

                Session["EmployeeMaster"] = employee_list;
                designations = _helper.Get_Designations();

                List<SelectListItem> ddl_designation = new List<SelectListItem>();
                foreach (Designation_Master designation in designations)
                {
                    ddl_designation.Add(new SelectListItem()
                    {
                        Value = designation.Designation_Id.ToString(),
                        Text = designation.Designation
                    });
                }
                ViewBag.ddl_designation = ddl_designation;

                ViewBag.Message = "Data saved successfully!!.";
            }
            else
            {
                ViewBag.Message = "Invalid Data.";
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult ViewEmployee(long Employee_Id)
        {
            Employee_Master employee = new Employee_Master();
            if (Employee_Id != 0)
            {
                List<Employee_Master> employee_list = new List<Employee_Master>();
                List<Designation_Master> designations = new List<Designation_Master>();
                Helper _helper = new Helper();
                employee_list = Session["EmployeeMaster"] is null ? new List<Employee_Master>() : (List<Employee_Master>)Session["EmployeeMaster"];
                if (employee_list != null && employee_list.Count > 0)
                {
                    employee = employee_list.Where(m => m.Employee_Id == Employee_Id).FirstOrDefault();
                }

                designations = _helper.Get_Designations();
                List<SelectListItem> ddl_designation = new List<SelectListItem>();
                foreach (Designation_Master designation in designations)
                {
                    ddl_designation.Add(new SelectListItem()
                    {
                        Value = designation.Designation_Id.ToString(),
                        Text = designation.Designation
                    });
                }
                ViewBag.ddl_designation = ddl_designation;
            }
            return View(employee);
        }
        [HttpGet]
        public ActionResult Delete(long Employee_Id)
        {
            List<Employee_Master> employee_list = new List<Employee_Master>();
            employee_list = Session["EmployeeMaster"] is null ? null : (List<Employee_Master>)Session["EmployeeMaster"];
            employee_list.Remove(employee_list.Single(s => s.Employee_Id == Employee_Id));
            Session["EmployeeMaster"] = employee_list;
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Attendance()
        {
            List<Employee_Attendance> attendances = new List<Employee_Attendance>();
            attendances = Session["Attendance"] is null ? null : (List<Employee_Attendance>)Session["Attendance"];
            Session["Attendance"] = attendances;
            List<Employee_Master> employee_list = new List<Employee_Master>();
            employee_list = Session["EmployeeMaster"] is null ? new List<Employee_Master>() : (List<Employee_Master>)Session["EmployeeMaster"];
            List<SelectListItem> ddl_employee = new List<SelectListItem>();
            foreach (Employee_Master employee in employee_list)
            {
                ddl_employee.Add(new SelectListItem()
                {
                    Value = employee.Employee_Id.ToString(),
                    Text = employee.Employee_First_name+" "+ employee.Employee_Last_Name
                });
            }
            ViewBag.ddl_employee = ddl_employee;
            return View(attendances);

        }
        [HttpPost] 
        public ActionResult SaveNewAttendance(Employee_Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                List<Employee_Attendance> attendances = new List<Employee_Attendance>();
                attendances = Session["Attendance"] is null ? new List<Employee_Attendance> (): (List<Employee_Attendance>)Session["Attendance"];                
                if (attendances != null && attendances.Count > 0)
                    attendance.Attendance_Id = attendances.Count + 1;
                else
                    attendance.Attendance_Id = 1;
                List<Employee_Master> employee_list = new List<Employee_Master>();
                employee_list = Session["EmployeeMaster"] is null ? new List<Employee_Master>() : (List<Employee_Master>)Session["EmployeeMaster"];
                if(employee_list !=null && employee_list.Count>0)
                {
                    attendance.Employee_name = employee_list.Where(m => m.Employee_Id == attendance.Employee_Id).Select(m => m.Employee_First_name + " " + m.Employee_Last_Name).FirstOrDefault();
                }


                attendances.Add(attendance);
                Session["Attendance"] = attendances;
                ViewBag.Message = "Employee data submitted successfully.";

            }
            else
            {
                ViewBag.Message = "Please enter correct data.";
            }
            return RedirectToAction("Attendance");
        }
        [HttpGet]
        public ActionResult EmployeesWithFiter(string Category, int Designation=0 )
        {
            List<Employee_Master> employee_list = new List<Employee_Master>();
            List<Designation_Master> designations = new List<Designation_Master>();
            employee_list = Session["EmployeeMaster"] is null ? null : (List<Employee_Master>)Session["EmployeeMaster"];
            
            if(employee_list!=null && Category != "" && Category !=null)
            {
                employee_list = employee_list.Where(m => m.Employee_category == Category).ToList();
            }
            if (employee_list != null && Designation != 0)
            {
                employee_list = employee_list.Where(m => m.Designation_Id == Designation).ToList();
            }



            Helper _helper = new Helper();
            designations = _helper.Get_Designations();
            List<SelectListItem> ddl_designation = new List<SelectListItem>();
            foreach (Designation_Master designation in designations)
            {
                ddl_designation.Add(new SelectListItem()
                {
                    Value = designation.Designation_Id.ToString(),
                    Text = designation.Designation
                });
            }
            ViewBag.ddl_designation = ddl_designation;
            return View(employee_list);
        }      

    }
}