using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BAL;
using Common;

namespace HRMS.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        EmployeeBAL manager = new EmployeeBAL();

        // GET: EmployeeList
        public ActionResult Index()
        {
            EmployeeListBE empList = new EmployeeListBE();
            empList = manager.GetEmployeeList();

            return View("Index", empList.EmployeeList);
        }

        //GET: Employee
        public ActionResult Edit(int empId, string userId)
        {
            //bool boolStatus = manager.UpdateEmployeeDetails();
            EmployeeBE emp = manager.GetEmployeeDetails(empId);
            return View("Edit", emp);
        }

        //POST: Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeBE emp)
        {
            bool boolStatus = manager.UpdateEmployeeDetails(emp.EmpId, emp.EmpCode, emp.FirstName, emp.LastName, emp.Designation, emp.IsPermanent, emp.Salary, emp.EmpImage);
            if (boolStatus)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", emp);
            }
        }

        public ActionResult Details(int empId)
        {
            try
            {
                EmployeeBE emp = manager.GetEmployeeDetails(empId);
                return View("Details", emp);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:- Details", ex);
                throw ex;
            }
        }

        //GET: Employee
        public ActionResult Delete(int empId, string userId)
        {
            try
            {
                EmployeeBE emp = manager.GetEmployeeDetails(empId);
                return View("Delete", emp);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:- Delete(Get Method)", ex);
                throw ex;
            }
        }

        //POST: Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int empId)
        {
            try
            {
                bool boolStatus = manager.DeleteEmployee(empId);
                if (boolStatus)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:- Delete(Post Method)", ex);
                throw ex;
            }
        }
    }
}