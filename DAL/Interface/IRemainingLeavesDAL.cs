using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace DAL.Interface
{
    public interface IRemainingLeavesDAL
    {
        RemainigLeavesListBE GetRemainingLeaves(int empId);
    }
}
