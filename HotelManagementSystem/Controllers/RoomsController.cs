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
    public class RoomsController : Controller
    {
        private RoomDb db = new RoomDb();

        // GET: Rooms
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.Accomodation).Include(r => r.Category).Include(r => r.RoomType);
            return View(rooms.ToList());
        }

        // GET: Rooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.Accomodations, "id", "Accomodation1");
            ViewBag.id = new SelectList(db.Categories, "id", "Category1");
            ViewBag.id = new SelectList(db.RoomTypes, "id", "RoomType1");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,roomNumber,accID,roomTypeID,catID,price")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.Accomodations, "id", "Accomodation1", room.id);
            ViewBag.id = new SelectList(db.Categories, "id", "Category1", room.id);
            ViewBag.id = new SelectList(db.RoomTypes, "id", "RoomType1", room.id);
            return View(room);
        }

        // GET: Rooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.Accomodations, "id", "Accomodation1", room.id);
            ViewBag.id = new SelectList(db.Categories, "id", "Category1", room.id);
            ViewBag.id = new SelectList(db.RoomTypes, "id", "RoomType1", room.id);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,roomNumber,accID,roomTypeID,catID,price")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.Accomodations, "id", "Accomodation1", room.id);
            ViewBag.id = new SelectList(db.Categories, "id", "Category1", room.id);
            ViewBag.id = new SelectList(db.RoomTypes, "id", "RoomType1", room.id);
            return View(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
