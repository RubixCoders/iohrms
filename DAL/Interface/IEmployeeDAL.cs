using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using BusinessEntities;

namespace DAL.Interface
{
    public interface IEmployeeDAL
    {
        /// Created By:- Surbhi Harsh
        /// Created Date:- 15-12-2015
        /// <summary>
        /// This Method is used to get the list of all Employees
        /// </summary>
        /// <returns>EmployeeList</returns>
        EmployeeListBE GetEmployeeList();

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
        bool UpdateEmployeeDetails(int empId, string empCode, string firstName, string lastName, string designation, bool isPermanent, double? salary, string empImage);

        /// Created By:- Surbhi Harsh
        /// Created On:- 15-12-2015
        /// <summary>
        /// This Method is used to get the details of an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>EmployeeBE</returns>
        EmployeeBE GetEmployeeDetails(int empId);

        /// Created By:- Surbhi Harsh
        /// Created On:- 15-12-2015
        /// <summary>
        /// This Method is used to delete an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>boolStatus</returns>
        bool DeleteEmployee(int empId);
    }
}
