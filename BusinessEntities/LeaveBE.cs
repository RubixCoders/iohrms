using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class LeaveBE
    {
        public int LeaveId { get; set; }
        public int EmpId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LeaveType { get; set; }
        public string LeaveReason { get; set; }
    }

    public class LeaveListBE
    {
        public List<LeaveBE> LeaveList { get; set; }
        public int Count { get; set; }
    }
}
