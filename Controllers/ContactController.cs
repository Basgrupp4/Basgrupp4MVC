using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Basgrupp4MVC.Models;

namespace Basgrupp4MVC.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactModels
        //public ActionResult Index()
        //{
        //    return View(db.ContactModels.ToList());
        //}
        public ActionResult Index(string searchString)
        {
            
            var contact = from c in db.ContactModels
                          select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                contact = contact.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));
            }

            return View(contact);
        }

        // GET: ContactModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModels contactModels = db.ContactModels.Find(id);
            if (contactModels == null)
            {
                return HttpNotFound();
            }
            return View(contactModels);
        }

        // GET: ContactModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Age,Email,EmailConfirm,PhoneNumber")] ContactModels contactModels)
        {
            if (ModelState.IsValid)
            {
                db.ContactModels.Add(contactModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactModels);
        }

        // GET: ContactModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModels contactModels = db.ContactModels.Find(id);
            if (contactModels == null)
            {
                return HttpNotFound();
            }
            return View(contactModels);
        }

        // POST: ContactModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Age,Email,EmailConfirm,PhoneNumber")] ContactModels contactModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactModels);
        }

        // GET: ContactModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactModels contactModels = db.ContactModels.Find(id);
            if (contactModels == null)
            {
                return HttpNotFound();
            }
            return View(contactModels);
        }

        // POST: ContactModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactModels contactModels = db.ContactModels.Find(id);
            db.ContactModels.Remove(contactModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
