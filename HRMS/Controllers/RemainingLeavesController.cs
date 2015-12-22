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
    public class RemainingLeavesController : Controller
    {
        RemainingLeavesBAL manager = new RemainingLeavesBAL();
        // GET: RemainingLeaves
        public ActionResult Index()
        {
            RemainigLeavesListBE remLeaves = manager.GetRemainingLeavesList(1011);
            return View(remLeaves.RemainingLeavesList);
        }
    }
}