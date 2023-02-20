using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstWithExistingDB.Models;

namespace CodeFirstWithExistingDB.Controllers
{
    public class WithPKsController : Controller
    {
        private ModelAzurePK db = new ModelAzurePK();

        // GET: WithPKs
        public ActionResult Index()
        {
            return View(db.WithPKs.ToList());
        }

        // GET: WithPKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithPK withPK = db.WithPKs.Find(id);
            if (withPK == null)
            {
                return HttpNotFound();
            }
            return View(withPK);
        }

        // GET: WithPKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WithPKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WithName")] WithPK withPK)
        {
            if (ModelState.IsValid)
            {
                db.WithPKs.Add(withPK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(withPK);
        }

        // GET: WithPKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithPK withPK = db.WithPKs.Find(id);
            if (withPK == null)
            {
                return HttpNotFound();
            }
            return View(withPK);
        }

        // POST: WithPKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WithName")] WithPK withPK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(withPK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(withPK);
        }

        // GET: WithPKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithPK withPK = db.WithPKs.Find(id);
            if (withPK == null)
            {
                return HttpNotFound();
            }
            return View(withPK);
        }

        // POST: WithPKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WithPK withPK = db.WithPKs.Find(id);
            db.WithPKs.Remove(withPK);
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
