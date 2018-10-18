using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miniPhoneweb.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
namespace miniPhoneweb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PhoneBookEntities db = new PhoneBookEntities();
            List<Person> list = db.People.ToList();
            List<PersonViewModel> viewList = new List<PersonViewModel>();
            List<PersonViewModel> update = new List<PersonViewModel>();
            int count = 0;
            foreach (Person p in list)
            {
                if (p.AddedBy == User.Identity.GetUserId())
                {
                    count++;
                }
            }
            ViewBag.TotalPeople = count;
            int Day = DateTime.Now.Day;
            int Month = DateTime.Now.Month;
            DateTime expire = DateTime.Now.AddDays(10);
            int nextDay = expire.Day;
            int nextMonth = expire.Month;
            foreach (Person p in list)
            {
                int pday = p.DateOfBirth.Value.Day;
                int pmonth = p.DateOfBirth.Value.Month;
                if (p.AddedBy == User.Identity.GetUserId())
                {
                    if ((pday >= Day && pday <= nextDay) && (pmonth >= Month && pmonth <= nextMonth))
                    {
                        PersonViewModel obj = new PersonViewModel();
                        obj.PersonId = p.PersonId;
                        obj.FirstName = p.FirstName;
                        obj.MiddleName = p.MiddleName;
                        obj.LastName = p.LastName;
                        obj.AddedOn = p.AddedOn;
                        //obj.AddedBy = p.AddedBy;
                        obj.DateOfBirth = p.DateOfBirth;
                        obj.HomeAddress = p.HomeAddress;
                        obj.HomeCity = p.HomeCity;
                        obj.FaceBookAccountId = p.FaceBookAccountId;
                        obj.LinkedInId = p.LinkedInId;
                        obj.UpdateOn = p.UpdateOn;
                        obj.TwitterId = p.TwitterId;
                        obj.EmailId = p.EmailId;
                        viewList.Add(obj);
                    }
                }
            }
           /* Multidata m1 = new Multidata();
            m1.Birthday = birthday;
            m1.Update = birthday;  */ 

            return View(viewList);
        }

            

           /* PhoneBookEntities db = new PhoneBookEntities();
            List<Person> list = db.People.ToList();
            List<PersonViewModel> viewList = new List<PersonViewModel>();
            int count = 0;
            foreach (Person p in list)
            {
                if (p.AddedBy == User.Identity.GetUserId())
                {
                    count++;
                }
            }
            ViewBag.TotalPeople = count;
            int Day = DateTime.Now.Day;
            int Month = DateTime.Now.Month; 
            DateTime expire = DateTime.Now.AddDays(10);
            int nextDay = expire.Day;
            int nextMonth = expire.Month;
            foreach (Person p in list)
            {
                int pday = p.DateOfBirth.Value.Day;
                int pmonth = p.DateOfBirth.Value.Month;
                if((pday>=Day && pday<=nextDay )&&( pmonth>=Month && pmonth<=nextMonth)) 
                {
                    PersonViewModel obj = new PersonViewModel();
                    obj.PersonId = p.PersonId;
                    obj.FirstName = p.FirstName;
                    obj.MiddleName = p.MiddleName;
                    obj.LastName = p.LastName;
                    obj.AddedOn = p.AddedOn;
                    //obj.AddedBy = p.AddedBy;
                    obj.DateOfBirth = p.DateOfBirth;
                    obj.HomeAddress = p.HomeAddress;
                    obj.HomeCity = p.HomeCity;
                    obj.FaceBookAccountId = p.FaceBookAccountId;
                    obj.LinkedInId = p.LinkedInId;
                    obj.UpdateOn = p.UpdateOn;
                    obj.TwitterId = p.TwitterId;
                    obj.EmailId = p.EmailId;
                    viewList.Add(obj);
                }

            }
                return View(viewList);
        }
        */
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
    }
}