using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using Common;
using BAL;

namespace HRMS.Controllers
{
    [Authorize]
    public class LeaveController : Controller
    {
        LeaveBAL manager = new LeaveBAL();
        // GET: Leave
        public ActionResult Index()
        {
            LeaveListBE leaveList = new LeaveListBE();
            leaveList = manager.GetLeaveList(2);
            return View(leaveList.LeaveList);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LeaveBE leave)
        {
            bool boolStatus = manager.AddLeave(leave);
            if (boolStatus)
                return RedirectToAction("Index");
            else
                return View(leave);
        }
    }
}