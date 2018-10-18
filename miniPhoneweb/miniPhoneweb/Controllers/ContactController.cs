using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miniPhoneweb.Models;
using System.Data.Entity;
namespace miniPhoneweb.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(int id)
        {

            PhoneBookEntities db = new PhoneBookEntities();    
            List<Contact> list = db.Contacts.ToList();
            List<ContactViewModel> viewList = new List<ContactViewModel>(); 
            foreach(Contact c1 in list)
            {

                if (c1.PersonId == id)
                {
                    ContactViewModel obj = new ContactViewModel();
                    obj.ContactNumber = c1.ContactNumber;
                    obj.Type = c1.Type;
                    obj.Contactid = c1.ContactId;
                    obj.PersonId = c1.PersonId;
                    viewList.Add(obj);
                }
            }
            return View(viewList);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            using (PhoneBookEntities db = new PhoneBookEntities())
            {
                return View(db.Contacts.Where(x => x.ContactId == id).FirstOrDefault());
            }
        }

        // GET: Contact/Create
        public ActionResult Create( int id)
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(int id , ContactViewModel obj)
        {
            try
            {
                Contact c1 = new Contact();
                c1.ContactNumber = obj.ContactNumber;
                c1.Type = obj.Type;
                c1.PersonId = id;
                PhoneBookEntities db = new PhoneBookEntities();
                
                db.Contacts.Add(c1);
                db.SaveChanges();
                //c1.PersonId = 
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            using (PhoneBookEntities db = new PhoneBookEntities())
            {
                return View(db.Contacts.Where(x => x.PersonId == id).FirstOrDefault());
            }
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact c1)
        {
            try
            {
                // TODO: Add update logic here
                using (PhoneBookEntities db = new PhoneBookEntities())
                {
                    db.Entry(c1).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
