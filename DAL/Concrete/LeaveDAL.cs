using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DAL.Model;
using DAL.Interface;
using Common;

namespace DAL.Concrete
{
    public class LeaveDAL : ILeaveDAL
    {
        dbHRMSEntities db = new dbHRMSEntities();

        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to get the list of leaves of an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>LeaveList</returns>
        public LeaveListBE GetLeaveList(int empId)
        {
            try
            {
                LeaveListBE leaveList = new LeaveListBE();
                leaveList.LeaveList = new List<LeaveBE>();
                var spData = db.sp_GetLeaveListByEmpId(empId).ToList();
                leaveList.Count = spData.Count();
                if (spData.Count() > 0)
                {
                    foreach (var item in spData)
                    {
                        LeaveBE leave = new LeaveBE();
                        leave.EmpId = (int)item.EmpId;
                        leave.FromDate = (DateTime)item.FromDate;
                        leave.LeaveId = item.LeaveId;
                        leave.LeaveReason = item.LeaveReason;
                        leave.LeaveType = item.LeaveType;
                        leave.ToDate = (DateTime)item.ToDate;
                        leaveList.LeaveList.Add(leave);
                    }
                }
                return leaveList;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveDAL:- GetLeaveList", ex);
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
        public bool AddLeave(LeaveBE leave)
        {
            try
            {
                int status = db.sp_AddLeave(leave.EmpId, leave.FromDate, leave.ToDate, leave.LeaveType, leave.LeaveReason);
                if (status > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveDAL:- AddLeave", ex);
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
        public LeaveBE GetLeaveDetails(int leaveId)
        {
            try
            {
                LeaveBE leave = new LeaveBE();
                var spData = db.sp_GetLeaveDetailsByLeaveId(leaveId);
                foreach (var item in spData)
                {
                    leave.EmpId = (int)item.EmpId;
                    leave.FromDate = (DateTime)item.FromDate;
                    leave.LeaveId = item.LeaveId;
                    leave.LeaveReason = item.LeaveReason;
                    leave.LeaveType = item.LeaveType;
                    leave.ToDate = (DateTime)item.ToDate;
                }
                return leave;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveDAL:- GetLeaveDetails", ex);
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
        public bool UpdateLeaveDetails(LeaveBE leave)
        {
            try
            {
                int status = db.sp_UpdateLeaveDetails(leave.LeaveId, leave.EmpId, leave.FromDate, leave.ToDate, leave.LeaveType, leave.LeaveReason);
                if (status > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveDAL:- UpdateLeaveDetails", ex);
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
        public bool DeleteLeave(int leaveId)
        {
            try
            {
                int status = db.sp_DeleteLeaveDetails(leaveId);
                if (status > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("LeaveDAL:- DeleteLeave", ex);
                throw;
            }
        }
    }
}
