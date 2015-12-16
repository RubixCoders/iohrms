using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Common;
using DAL.Interface;
using DAL.Concrete;

namespace BAL
{
    public class LeaveBAL
    {
        ILeaveDAL dal = new LeaveDAL();

        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to get the list of leaves of an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>LeaveList</returns>
        public LeaveListBE GetLeaveList(int empId) {
            try
            {
                return dal.GetLeaveList(empId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveBAL:- GetLeaveList", ex);
                throw ex;
            }
        }

        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to Add Leave for an Employee
        /// </summary>
        /// <param name="leave"></param>
        /// <returns>boolStatus</returns>
        public bool AddLeave(LeaveBE leave) {
            try
            {
                return dal.AddLeave(leave);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveBAL:- AddLeave", ex);
                throw ex;
            }
        }
    }
}
