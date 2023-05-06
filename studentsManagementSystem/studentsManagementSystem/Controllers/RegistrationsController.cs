using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using studentsManagementSystem.Models;

namespace studentsManagementSystem.Controllers
{
    public class RegistrationsController : Controller
    {
        private SystemManageEntities db = new SystemManageEntities();

        // GET: Registrations
        public ActionResult Index()
        {
            var registration = db.Registration.Include(r => r.batch).Include(r => r.Cource);
            return View(registration.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1");
            ViewBag.cource_id = new SelectList(db.Cource, "id", "cource1");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,NIC,cource_id,batch_id,phone")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registration.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1", registration.batch_id);
            ViewBag.cource_id = new SelectList(db.Cource, "id", "cource1", registration.cource_id);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1", registration.batch_id);
            ViewBag.cource_id = new SelectList(db.Cource, "id", "cource1", registration.cource_id);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,NIC,cource_id,batch_id,phone")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.batch_id = new SelectList(db.batch, "id", "batch1", registration.batch_id);
            ViewBag.cource_id = new SelectList(db.Cource, "id", "cource1", registration.cource_id);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registration.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registration.Find(id);
            db.Registration.Remove(registration);
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
