using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DAL.Interface
{
    public interface ILeaveDAL
    {
        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to get the list of leaves of an Employee
        /// </summary>
        /// <param name="empId"></param>
        /// <returns>LeaveList</returns>
        LeaveListBE GetLeaveList(int empId);

        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to Add Leave for an Employee
        /// </summary>
        /// <param name="leave"></param>
        /// <returns>boolStatus</returns>
        bool AddLeave(LeaveBE leave);
        
        /// Created By:- Surbhi Harsh
        /// Created On:- 16-12-2015
        /// <summary>
        /// This Method is used to get the details of a leave.
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns>Leave</returns>
        LeaveBE GetLeaveDetails(int leaveId);

        /// Created By:- Surbhi Harsh
        /// Created On:- 17-12-2015
        /// <summary>
        /// This Method is used to update the details of an Employee
        /// </summary>
        /// <param name="leave"></param>
        /// <returns>boolStatus</returns>
        bool UpdateLeaveDetails(LeaveBE leave);

        /// Created By:- Surbhi Harsh
        /// Created On:- 17-12-2015
        /// <summary>
        /// This Method is used to delete a leave from records.
        /// </summary>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        bool DeleteLeave(int leaveId);
    }
}
