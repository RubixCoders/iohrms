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

        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to get the details of a leave.
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns>Leave</returns>
        public LeaveBE GetLeaveDetails(int leaveId) {
            try
            {
                return dal.GetLeaveDetails(leaveId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveBAL:- GetLeaveDetails", ex);
                throw ex;
            }
        }

        /// Created By:- Surbhi Harsh
        /// Created On:- 17-12-2015
        /// <summary>
        /// This Method is used to update the details of an Employee
        /// </summary>
        /// <param name="leave"></param>
        /// <returns>boolStatus</returns>
        public bool UpdateLeaveDetails(LeaveBE leave) {
            try
            {
                return dal.UpdateLeaveDetails(leave);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveBAL:- UpdateLeaveDetails", ex);
                throw ex;
            }
        }

        /// Created By:- Surbhi Harsh
        /// Created On:- 17-12-2015
        /// <summary>
        /// This Method is used to delete a leave from records.
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        public bool DeleteLeave(int leaveId) {
            try
            {
                return dal.DeleteLeave(leaveId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveBAL:- DeleteLeave", ex);
                throw ex;
            }
        }
    }
}
