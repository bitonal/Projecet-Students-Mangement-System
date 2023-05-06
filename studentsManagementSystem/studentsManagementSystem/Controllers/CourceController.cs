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
    public class CourceController : Controller
    {
        private SystemManageEntities db = new SystemManageEntities();

        // GET: Cource
        public ActionResult Index()
        {
            return View(db.Cource.ToList());
        }

        // GET: Cource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cource cource = db.Cource.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }
            return View(cource);
        }

        // GET: Cource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cource/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cource1,duration")] Cource cource)
        {
            if (ModelState.IsValid)
            {
                db.Cource.Add(cource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cource);
        }

        // GET: Cource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cource cource = db.Cource.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }
            return View(cource);
        }

        // POST: Cource/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cource1,duration")] Cource cource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cource);
        }

        // GET: Cource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cource cource = db.Cource.Find(id);
            if (cource == null)
            {
                return HttpNotFound();
            }
            return View(cource);
        }

        // POST: Cource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cource cource = db.Cource.Find(id);
            db.Cource.Remove(cource);
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
