using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDocTruyen.Models;

namespace WebDocTruyen.Controllers
{
    public class CHUONGTRUYENsController : Controller
    {
        private DB_Chapter db = new DB_Chapter();

        // GET: CHUONGTRUYENs
        public ActionResult Index()
        {
            return View(db.CHUONGTRUYENs.ToList());
        }

        // GET: CHUONGTRUYENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUONGTRUYEN cHUONGTRUYEN = db.CHUONGTRUYENs.Find(id);
            if (cHUONGTRUYEN == null)
            {
                return HttpNotFound();
            }
            return View(cHUONGTRUYEN);
        }

        // GET: CHUONGTRUYENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHUONGTRUYENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDCHAP,IDTRUYEN,TENCHAP,LINKTRUYEN,BATDAU,KETTHUC,DUOIANH,LUOTXEM,LUOTTHEODOI,TIMEPOST")] CHUONGTRUYEN cHUONGTRUYEN)
        {
            if (ModelState.IsValid)
            {
                cHUONGTRUYEN.TIMEPOST = DateTime.Now;
                db.CHUONGTRUYENs.Add(cHUONGTRUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHUONGTRUYEN);
        }

        // GET: CHUONGTRUYENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUONGTRUYEN cHUONGTRUYEN = db.CHUONGTRUYENs.Find(id);
            if (cHUONGTRUYEN == null)
            {
                return HttpNotFound();
            }
            return View(cHUONGTRUYEN);
        }

        // POST: CHUONGTRUYENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDCHAP,IDTRUYEN,TENCHAP,LINKTRUYEN,BATDAU,KETTHUC,DUOIANH,LUOTXEM,LUOTTHEODOI,TIMEPOST")] CHUONGTRUYEN cHUONGTRUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHUONGTRUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHUONGTRUYEN);
        }

        // GET: CHUONGTRUYENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHUONGTRUYEN cHUONGTRUYEN = db.CHUONGTRUYENs.Find(id);
            if (cHUONGTRUYEN == null)
            {
                return HttpNotFound();
            }
            return View(cHUONGTRUYEN);
        }

        // POST: CHUONGTRUYENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHUONGTRUYEN cHUONGTRUYEN = db.CHUONGTRUYENs.Find(id);
            db.CHUONGTRUYENs.Remove(cHUONGTRUYEN);
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
