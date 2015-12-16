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
        public bool AddLeave(LeaveBE leave) {
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
    }
}
