using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagementSystem.Models;

namespace HotelManagementSystem.Controllers
{
    public class AccomodationsController : Controller
    {
        private RoomDb db = new RoomDb();

        // GET: Accomodations
        public ActionResult Index()
        {
            var accomodations = db.Accomodations.Include(a => a.Room);
            return View(accomodations.ToList());
        }

        // GET: Accomodations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomodation accomodation = db.Accomodations.Find(id);
            if (accomodation == null)
            {
                return HttpNotFound();
            }
            return View(accomodation);
        }

        // GET: Accomodations/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Rooms, "id", "id");
            return View();
        }

        // POST: Accomodations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Accomodation1")] Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {
                db.Accomodations.Add(accomodation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Rooms, "id", "id", accomodation.id);
            return View(accomodation);
        }

        // GET: Accomodations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomodation accomodation = db.Accomodations.Find(id);
            if (accomodation == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Rooms, "id", "id", accomodation.id);
            return View(accomodation);
        }

        // POST: Accomodations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Accomodation1")] Accomodation accomodation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accomodation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Rooms, "id", "id", accomodation.id);
            return View(accomodation);
        }

        // GET: Accomodations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomodation accomodation = db.Accomodations.Find(id);
            if (accomodation == null)
            {
                return HttpNotFound();
            }
            return View(accomodation);
        }

        // POST: Accomodations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accomodation accomodation = db.Accomodations.Find(id);
            db.Accomodations.Remove(accomodation);
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
