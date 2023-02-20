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
    public class WithoutPKsController : Controller
    {
        private ModelAzureNoPK db = new ModelAzureNoPK();

        // GET: WithoutPKs
        public ActionResult Index()
        {
            return View(db.WithoutPKs.ToList());
        }

        // GET: WithoutPKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithoutPK withoutPK = db.WithoutPKs.Find(id);
            if (withoutPK == null)
            {
                return HttpNotFound();
            }
            return View(withoutPK);
        }

        // GET: WithoutPKs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WithoutPKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WithoutName")] WithoutPK withoutPK)
        {
            if (ModelState.IsValid)
            {
                db.WithoutPKs.Add(withoutPK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(withoutPK);
        }

        // GET: WithoutPKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithoutPK withoutPK = db.WithoutPKs.Find(id);
            if (withoutPK == null)
            {
                return HttpNotFound();
            }
            return View(withoutPK);
        }

        // POST: WithoutPKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WithoutName")] WithoutPK withoutPK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(withoutPK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(withoutPK);
        }

        // GET: WithoutPKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WithoutPK withoutPK = db.WithoutPKs.Find(id);
            if (withoutPK == null)
            {
                return HttpNotFound();
            }
            return View(withoutPK);
        }

        // POST: WithoutPKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WithoutPK withoutPK = db.WithoutPKs.Find(id);
            db.WithoutPKs.Remove(withoutPK);
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
