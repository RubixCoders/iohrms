using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class RemainingLeavesBE
    {
        public int MonthId { get; set; }
        public int CL { get; set; }
        public int PL { get; set; }
        public int CompOff { get; set; }
        public string Month { get; set; }
    }
    public class RemainigLeavesListBE
    {
        public List<RemainingLeavesBE> RemainingLeavesList { get; set; }
        public int Count { get; set; }
    }
}
