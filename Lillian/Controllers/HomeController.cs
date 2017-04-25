using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lillian.Models;
using System.Data.Entity.Infrastructure;

namespace Lillian.Controllers
{
    public class HomeController : Controller
    {

#region default 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
#endregion

#region display all Staff
        IC_MotersEntities db = new IC_MotersEntities();

        public ActionResult AllStaff()
        {
            List<Person> allStaff = (from s in db.People where s.PersonTypeId != 4 select s).ToList();
            return View(allStaff);
        }
#endregion

#region edit staff
        public ActionResult staffEdit(int staffid)
        {

            Person StafftoEdit = (from s in db.People where s.PersonId == staffid select s).FirstOrDefault();
           IEnumerable< SelectListItem > tyeList = (from t in db.PersonTypes where t.PersonTypeId!=4 select t).ToList()
                                        .Select(c => new SelectListItem { Value = c.PersonTypeId.ToString(), Text = c.Name });
            ViewBag.persontypeList = tyeList;
            return View(StafftoEdit);
        }

        [HttpPost]
        public ActionResult staffEdit(Person editS)
        {
            var changedStaff = db.People.Find(editS.PersonId);
            changedStaff.FirstName = editS.FirstName.Trim();
            changedStaff.Address1 = editS.Address1.Trim();
            changedStaff.PersonTypeId = editS.PersonTypeId;
            db.SaveChanges();
            return RedirectToAction("AllStaff","Home");
        }
#endregion

#region del staff
        public ActionResult staffDel(int staffid)
        {
            try {
                
                Person selStaff = new Person() { PersonId = staffid };
                db.People.Attach(selStaff);
                db.People.Remove(selStaff);
                db.SaveChanges();
                return RedirectToAction("AllStaff", "Home");
                }
            catch(Exception ex)
               {
                return Content("Del Fail!"+ex.Message);
               }
        }
        #endregion

#region Add a staff
        public ActionResult staffAdd()
        {
            IEnumerable<SelectListItem> perType = (from pt in db.PersonTypes where pt.PersonTypeId != 4 select pt).ToList()
                                                 .Select(p => new SelectListItem { Value = p.PersonTypeId.ToString(), Text = p.Name });
            ViewBag.perType = perType;
            IEnumerable<SelectListItem> SurID = (from s in db.SuburbTypes select s).ToList()
                                             .Select(s => new SelectListItem { Value = s.SuburbId.ToString(), Text = s.Name });
            ViewBag.SurID = SurID;
            return View();
        }
        [HttpPost]
        public ActionResult staffAdd(Person newp)
        {
            Person addP = new Person()
            {
                FirstName=newp.FirstName,
                LastName=newp.LastName,
                Salary=newp.Salary,
                PersonTypeId=newp.PersonTypeId,
                Address1=newp.Address1,
                SuburbId=newp.SuburbId,
                PhoneNumber=newp.PhoneNumber
            };
            db.People.Add(addP);
            db.SaveChanges();
            return RedirectToAction("AllStaff", "Home");
        }
        #endregion

#region Search
      
        public ActionResult Search(string key)
        {
            List<Person> searchP = (from p in db.People where p.FirstName==key select p).ToList();
            return View(searchP);
        }
#endregion
    }
}