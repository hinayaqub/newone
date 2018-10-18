using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using miniPhoneweb.Models;
using System.Data.Entity;
namespace miniPhoneweb.Controllers
{
    public class PersonController : Controller
    {
       // <label> Total Number Of Persons:  </label>@ViewBag.TotalPeople
        // GET: Person
        public ActionResult Index()
        {
            PhoneBookEntities db = new PhoneBookEntities();
            List<Person> list = db.People.ToList();
            List<PersonViewModel> viewList = new List<PersonViewModel>();
                   
                    foreach (Person p in list)
                    {
                 if (p.AddedBy == User.Identity.GetUserId())
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

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            using (PhoneBookEntities db = new PhoneBookEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).FirstOrDefault());
            }
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonViewModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                Person p = new Person();
                p.FirstName = obj.FirstName;
                p.MiddleName = obj.MiddleName;
                p.LastName = obj.LastName;
                ///  String y = ((DateTime)obj.DateOfBirth).GetDateTimeFormats()[0];
                p.DateOfBirth = obj.DateOfBirth;

                p.HomeAddress = obj.HomeAddress;
                p.HomeCity = obj.HomeCity;
                p.FaceBookAccountId = obj.FaceBookAccountId;
                p.LinkedInId = obj.LinkedInId;
                p.AddedOn = DateTime.Now;
                p.UpdateOn = Convert.ToDateTime(obj.UpdateOn);
                p.TwitterId = obj.TwitterId;
                p.EmailId = obj.EmailId;
                String id = "";
                PhoneBookEntities db = new PhoneBookEntities();
                List<AspNetUser> userlist = db.AspNetUsers.ToList();

                p.AddedBy = User.Identity.GetUserId();

                



                db.People.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            using (PhoneBookEntities db = new PhoneBookEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).FirstOrDefault());
            }
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Person p)
        {
            try
            {
                using (PhoneBookEntities db = new PhoneBookEntities())
                {
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();
                }

                    // TODO: Add update logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            using (PhoneBookEntities db = new PhoneBookEntities())
            {
                return View(db.People.Where(x => x.PersonId == id).FirstOrDefault());
            }
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (PhoneBookEntities db = new PhoneBookEntities())
                {
                    Person p = db.People.Where(x => x.PersonId == id).FirstOrDefault();
                    db.People.Remove(p);
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
