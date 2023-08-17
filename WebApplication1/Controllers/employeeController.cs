using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace WebApplication1.Controllers
{
    public class employeeController : ApiController
    {
        // GET: Default
        

            [HttpGet]
            public List<employee> GetemployeeList()
            {
            employeedbEntities1 employeeDBEntities = new employeedbEntities1();
                List<employee> employees = employeeDBEntities.employees.ToList();
                return employees;
            }
            [HttpGet]
            public employee GetemployeeById(int id)
            {
            employeedbEntities1 employeeDBEntities = new employeedbEntities1();
                employee emp = employeeDBEntities.employees.Find(id);
                return emp;
            }
        [System.Web.Http.HttpPost]
            public string Createemployee(employee employee)
            {
                string msg = string.Empty;
                employee emp = new employee();
            employeedbEntities1 employeeDBEntities = new employeedbEntities1();
                emp.empid = employee.empid;
                emp.empname = employee.empname;
                emp.empaddress = employee.empaddress;
                employeeDBEntities.employees.Add(emp);
                employeeDBEntities.SaveChanges();
                msg = "employee Record is inserted";
                return msg;
            }
            [System.Web.Http.HttpPut]
            public string UpdateEmployee(employee employee)
            {

                string msg = string.Empty;

            employeedbEntities1 employeeDBEntities = new employeedbEntities1();
                employee emp = employeeDBEntities.employees.Find(employee.empid);

                emp.empname = employee.empname;
                emp.empaddress = employee.empaddress;

                employeeDBEntities.SaveChanges();
                msg = "Employee Record updated";
                return msg;
            }
            [System.Web.Http.HttpDelete]
            public string DeleteEmployee(int id)
            {

                string msg = string.Empty;
            employeedbEntities1 employeeDBEntities = new employeedbEntities1();
                employee emp = employeeDBEntities.employees.Find(id);
                employeeDBEntities.employees.Remove(emp);
                employeeDBEntities.SaveChanges();
                msg = "Employee record is deleted";


                return msg;


            }
        }
    }

        