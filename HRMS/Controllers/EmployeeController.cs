using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BAL;
using Common;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using HRMS.Models;
using System.Configuration;
namespace HRMS.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {

          private ApplicationUserManager _userManager;

        public EmployeeController()
        {
        }

        public EmployeeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;

        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        EmployeeBAL manager = new EmployeeBAL();

        // GET: EmployeeList
        public ActionResult Index()
        {
            EmployeeListBE empList = new EmployeeListBE();
            empList = manager.GetEmployeeList();

            return View("Index", empList.EmployeeList);
        }

        //GET: Employee
        public ActionResult Edit(int empId, string userId)
        {
            //bool boolStatus = manager.UpdateEmployeeDetails();
            EmployeeBE emp = manager.GetEmployeeDetails(empId);
            return View("Edit", emp);
        }

        //POST: Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeBE emp)
        {
            bool boolStatus = manager.UpdateEmployeeDetails(emp.EmpId, emp.EmpCode, emp.FirstName, emp.LastName, emp.Designation, emp.IsPermanent, emp.Salary, emp.EmpImage);
            if (boolStatus)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit", emp);
            }
        }

        public ActionResult Details(int empId)
        {
            try
            {
                EmployeeBE emp = manager.GetEmployeeDetails(empId);
                return View("Details", emp);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:- Details", ex);
                throw ex;
            }
        }

        //GET: Employee
        public ActionResult Delete(int empId, string userId)
        {
            try
            {
                EmployeeBE emp = manager.GetEmployeeDetails(empId);
                return View("Delete", emp);
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:- Delete(Get Method)", ex);
                throw ex;
            }
        }

        //POST: Employee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int empId)
        {
            try
            {
                bool boolStatus = manager.DeleteEmployee(empId);
                if (boolStatus)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:- Delete(Post Method)", ex);
                throw ex;
            }
        }



        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeBE emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegisterViewModel model = new RegisterViewModel();
                    model.Email = emp.Email;
                    model.Role = "Employee";
                    var userid = RegisterEmployee(model, emp.FirstName + " " + emp.LastName);
                    if (userid != null)
                    {
                        emp.UserId = userid;
                        bool status = manager.AddEmployee(emp);
                        if (status)
                        {
                            return Index();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Something went Wrong ");
                            return View(emp);
                        }
                        // return Index();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went Wrong ");
                        return View(emp);
                    }
                }
                else
                {
                    return View(emp);
                }
            }
            catch (Exception ex)
            {
                LogManager.logger.Error("EmployeeController:-AddEmployee", ex);
                throw ex;
            }

        }

        public string RegisterEmployee(RegisterViewModel model, string fullName)
        {
            HRMS.CommonWebFunction.PasswordGeneration pwd = new CommonWebFunction.PasswordGeneration();
            model.Password = pwd.GenerateStrongPassword(8);
            if (ModelState.ContainsKey("Password"))
                ModelState["Password"].Errors.Clear();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                IdentityResult result = UserManager.Create(user, model.Password);
                //to add roles
                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, model.Role);
                    string code = UserManager.GenerateEmailConfirmationToken(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(
                    new System.Net.Mail.MailAddress("mayank.chaturvedi@infoobjects.com", "Web Registration"),
                    new System.Net.Mail.MailAddress(user.Email));
                    m.Subject = "Email confirmation";
                    m.Body = string.Format("Dear " + fullName + ",<BR/>" + Session["UserName"].ToString() + " has shared some details for project with you" + "<BR/><BR/> Your UserName: " + model.Email + " <br/>Password: " + model.Password + " <BR/> <br/> <br/ >Please click on the below link to complete your registration: <a href=\"" + callbackUrl + "\">here</a>.<BR/> <BR/> Thanks!");
                    m.IsBodyHtml = true;
                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["SenderEmail"], ConfigurationManager.AppSettings["SenderPassword"]);
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    return user.Id;
                }
                else
                {
                    AddErrors(result);
                }
            }
            // If we got this far, something failed
            return null;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}