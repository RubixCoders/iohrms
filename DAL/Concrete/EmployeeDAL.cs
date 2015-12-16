using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using BusinessEntities;
using DAL.Interface;
using Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace DAL.Concrete
{
    public class EmployeeDAL : IEmployeeDAL
    {
        dbHRMSEntities db = new dbHRMSEntities();

        #region EmployeeList
        /// Created By:- Surbhi Harsh
        /// Created Date:- 15-12-2015
        /// <summary>
        /// This Method is used to get the list of Employees
        /// </summary>
        /// <returns>EmployeeList</returns>
        public EmployeeListBE GetEmployeeList() {
            try
            {
                EmployeeListBE empList = new EmployeeListBE();
                empList.EmployeeList = new List<EmployeeBE>();
                var spData = db.sp_GetEmployeeList().ToList();
                if(spData.Count>0){
                    empList.Count = spData.Count;
                    foreach(var item in spData){
                        EmployeeBE emp = new EmployeeBE();
                        emp.Designation = item.Designation;
                        emp.EmpCode = item.EmpCode;
                        emp.EmpId = item.EmpId;
                        emp.EmpImage = item.EmpImage;
                        emp.FirstName = item.FirstName;
                        emp.IsPermanent = item.IsPermanent;
                        emp.LastName = item.LastName;
                        emp.Salary = item.Salary;
                        emp.UserId = item.UserId;
                        empList.EmployeeList.Add(emp);
                    }
                } else{
                    empList.EmployeeList = null;
                    empList.Count=0;
                }
                return empList;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeDAL:- GetEmployeeDetails", ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        /// Created By:- Surbhi Harsh
        /// Created On:- 15-12-2015
        /// <summary>
        /// This Method is used to update the details of an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="empCode"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="designation"></param>
        /// <param name="isPermanent"></param>
        /// <param name="salary"></param>
        /// <param name="empImage"></param>
        /// <returns>bool Status</returns>
        public bool UpdateEmployeeDetails(int empId, string empCode, string firstName, string lastName, string designation, bool isPermanent, double? salary, string empImage) { 
            try 
	        {
                var spData = db.sp_EditEmployeeDetails(empId, empCode, firstName, lastName, designation, isPermanent, salary, empImage);
                return true;
	        }
	        catch (Exception ex)
	        {
                LogManager.logger.Error("EmployeeDAL:- UpdateEmployeeDetails", ex);
		        throw ex;
	        }
        }
        #endregion

        #region EmployeeDetails
        /// Created By:- Surbhi Harsh
        /// Created On:- 15-12-2015
        /// <summary>
        /// This Method is used to get the details of an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>EmployeeBE</returns>
        public EmployeeBE GetEmployeeDetails(int empId) {
            try
            {
                EmployeeBE emp = new EmployeeBE();
                var spData = db.sp_GetEmployeeById(empId);
                foreach (var item in spData) {
                    emp.Designation = item.Designation;
                    emp.EmpCode = item.EmpCode;
                    emp.EmpId = item.EmpId;
                    emp.EmpImage = item.EmpImage;
                    emp.FirstName = item.FirstName;
                    emp.IsPermanent = item.IsPermanent;
                    emp.LastName = item.LastName;
                    emp.Salary = item.Salary;
                    emp.UserId = item.UserId;
                }
                return emp;

            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeDAL:- GetEmployeeDetails", ex);
                throw ex;
            }
        }
        #endregion

        #region Delete
        /// Created By:- Surbhi Harsh
        /// Created On:- 15-12-2015
        /// <summary>
        /// This Method is used to delete an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>boolStatus</returns>
        public bool DeleteEmployee(int empId) {
            try
            {
                int status = db.sp_DeleteEmployeeById(empId);
                if (status > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeDAL:- DeleteEmployee", ex);
                throw ex;
            }
        }
        #endregion
    }
}
