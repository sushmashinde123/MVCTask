using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTask.Models;
namespace MVCTask.Controllers
{
    public class EmployeeController : Controller
    {
        EmPortalEntities db;
        public EmployeeController()
        {
            db = new EmPortalEntities();
        }

        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(EmployeeModel e)
        {
            if(e.password!=e.confirm_password)
            {
                ViewBag.msg = "Password and Confirm password are not matched";
                return View();
            }
            else
            {
                tblemployee_details emp = new tblemployee_details() { first_name = e.first_name, last_name = e.last_name, password = e.password, email_Address = e.email_Address, birth_date = e.birth_date };
                db.tblemployee_details.Add(emp);
                db.SaveChanges();
 
                return RedirectToAction("Success");
            }


        }

        public ActionResult Success() {

            return View();

        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblemployee_details e)
        {

            tblemployee_details emp = db.tblemployee_details.ToList().FirstOrDefault(p => p.email_Address.Equals(e.email_Address) & p.password.Equals(e.password));
            if(emp==null)
            {
                ViewBag.msg = "Invalid Email Address or Password";
                return View();
            }
            else
            {
                Session["employee_name"] = emp.first_name + " " + emp.last_name;
                Session["employee_id"] = emp.employee_id;
                return RedirectToAction("Dashboard");
            }
        }
        public ActionResult Dashboard()
        {
            if(Session["employee_id"]==null)
            {
                return RedirectToAction("Login");

            }
            else
            {
                int id = Convert.ToInt32(Session["employee_id"].ToString());
                tblemployee_details e = db.tblemployee_details.Find(id);
                
                
                return View(e);

            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["employee_id"] = null;
            Session["employee_name"] = null;
            return RedirectToAction("Login");
        }
    }
}