using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
using DAL.Interface;
using BusinessEntities;
using Common;

namespace BAL
{
    public class EmployeeBAL
    {
        IEmployeeDAL dal = new EmployeeDAL();

        /// Created By:- Surbhi Harsh
        /// Created Date:- 15-12-2015
        /// <summary>
        /// This is Method is used to get the list of Employees.
        /// </summary>
        /// <returns>EmployeeList</returns>
        public EmployeeListBE GetEmployeeList()
        {
            try
            {
                return dal.GetEmployeeList();
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:- GetEmployeeList", ex);
                throw ex;
            }
        }

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
        public bool UpdateEmployeeDetails(int empId, string empCode, string firstName, string lastName, string designation, bool isPermanent, double? salary, string empImage)
        {
            try
            {
                return dal.UpdateEmployeeDetails(empId,empCode,firstName,lastName,designation,isPermanent,salary,empImage);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:- UpdateEmployeeDetails", ex);
                throw ex;
            }
        }

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
                return dal.GetEmployeeDetails(empId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:- GetEmployeeDetails", ex);
                throw ex;
            }
        }

        public EmployeeBE GetEmployeeDetailsByUserId(string userId)
        {
            try
            {
                return dal.GetEmployeeDetailsByUserId(userId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:- GetEmployeeDetailsByUserId", ex);
                throw ex;
            }
        }

        /// Created By:- Surbhi Harsh
        /// Created On:- 15-12-2015
        /// <summary>
        /// This Method is used to delete an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>boolStatus</returns>
        /// 
        public bool DeleteEmployee(int empId) {
            try
            {
                return dal.DeleteEmployee(empId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:- DeleteEmployee", ex);
                throw;
            }
        }

        #region Employee Create
        /// CreatedBy:-Mayank
        /// CreatedDate:-17-12-2015
        /// <summary>
        /// This method is used to create Employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public bool AddEmployee(EmployeeBE emp)
        {

            try
            {
                return dal.AddEmployee(emp);


            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:-EmployeeBE", ex);
                throw ex;

            }
        }
        #endregion

        #region Allot Leaves
        public bool AllotLeaves(int empId) {
            try
            {
                return dal.AllotLeaves(empId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeBAL:- AllotLeaves", ex);
                throw ex;
            }
        }
        #endregion
    }
}
