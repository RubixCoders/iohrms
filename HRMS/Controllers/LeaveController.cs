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

        public ActionResult Details(int leaveId)
        {
            LeaveBE leave = manager.GetLeaveDetails(leaveId);
            return View(leave);
        }

        //GET: Leave
        public ActionResult Edit(int leaveId)
        {
            LeaveBE leave = manager.GetLeaveDetails(leaveId);
            return View(leave);
        }

        //POST: Leave
        [HttpPost]
        public ActionResult Edit(LeaveBE leave)
        {
            bool boolStatus = manager.UpdateLeaveDetails(leave);
            if (boolStatus)
                return RedirectToAction("Index");
            else
                return View(leave);
        }

        //GET: Leave
        public ActionResult Delete(int leaveId)
        {
            LeaveBE leave = manager.GetLeaveDetails(leaveId);
            return View(leave);
        }

        [HttpPost]
        public ActionResult Delete(LeaveBE leave)
        {
            bool boolStatus = manager.DeleteLeave(leave.LeaveId);
            if (boolStatus)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Delete", new { id = leave.LeaveId });
        }
    }
}