using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using DAL.Concrete;
using Common;
using BusinessEntities;

namespace BAL
{
    public class RemainingLeavesBAL
    {
        RemainingLeavesDAL dal = new RemainingLeavesDAL();
        public RemainigLeavesListBE GetRemainingLeavesList(int empId)
        {
            try
            {
                return dal.GetRemainingLeaves(empId);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("RemainingLeavesBAL:- GetRemainingLeavesList", ex);
                throw;
            }
        }
    }
}
