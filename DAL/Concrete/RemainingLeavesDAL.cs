using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Model;
using BusinessEntities;
using DAL.Interface;

namespace DAL.Concrete
{
    public class RemainingLeavesDAL : IRemainingLeavesDAL
    {
        dbHRMSEntities db = new dbHRMSEntities();

        #region Get Remaining Leaves
        public RemainigLeavesListBE GetRemainingLeaves(int empId)
        {
            try
            {
                var spData = db.sp_GetRemainingLeaves(empId).ToList();
                RemainigLeavesListBE remLeaves = new RemainigLeavesListBE();
                remLeaves.Count = spData.Count;
                remLeaves.RemainingLeavesList = new List<RemainingLeavesBE>();
                foreach (var item in spData)
                {
                    RemainingLeavesBE remLeaveEntity = new RemainingLeavesBE();
                    remLeaveEntity.CL = (int)item.CL;
                    remLeaveEntity.CompOff = (int)item.CompOff;
                    remLeaveEntity.MonthId = item.MonthId;
                    remLeaveEntity.PL = (int)item.PL;

                    switch (item.MonthId)
                    {
                        case 1:
                            {
                                remLeaveEntity.Month = "Jan";
                                break;
                            }
                        case 2:
                            {
                                remLeaveEntity.Month = "Feb";
                                break;
                            }
                        case 3:
                            {
                                remLeaveEntity.Month = "Mar";
                                break;
                            }
                        case 4:
                            {
                                remLeaveEntity.Month = "April";
                                break;
                            }
                        case 5:
                            {
                                remLeaveEntity.Month = "May";
                                break;
                            }
                        case 6:
                            {
                                remLeaveEntity.Month = "Jun";
                                break;
                            }
                        case 7:
                            {
                                remLeaveEntity.Month = "July";
                                break;
                            }
                        case 8:
                            {
                                remLeaveEntity.Month = "Aug";
                                break;
                            }
                        case 9:
                            {
                                remLeaveEntity.Month = "Sept";
                                break;
                            }
                        case 10:
                            {
                                remLeaveEntity.Month = "Oct";
                                break;
                            }
                        case 11:
                            {
                                remLeaveEntity.Month = "Nov";
                                break;
                            }
                        case 12:
                            {
                                remLeaveEntity.Month = "Dec";
                                break;
                            }
                        default:
                            {
                                remLeaveEntity.Month = "Invalid Month ID";
                                break;
                            }
                    }
                    remLeaves.RemainingLeavesList.Add(remLeaveEntity);
                }
                return remLeaves;
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("RemainingLeavesDAL:- GetRemainingLeaves", ex);
                throw ex;
            }
        }
        #endregion
    }
}
