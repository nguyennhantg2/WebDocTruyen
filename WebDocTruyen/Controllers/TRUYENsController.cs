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
    public class TRUYENsController : Controller
    {
        private DB_Truyen db = new DB_Truyen();

        // GET: TRUYENs
        public ActionResult Index()
        {
            return View(db.TRUYENs.ToList());
        }

        // GET: TRUYENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRUYEN tRUYEN = db.TRUYENs.Find(id);
            Session["tentruyen"] = tRUYEN.TENTRUYEN;

            //DB_Chapter dbc = new DB_Chapter();
            //var data_c = dbc.CHUONGTRUYENs.Where(s => s.IDTRUYEN.Equals(id)).ToList();

            if (tRUYEN == null)
            {
                return HttpNotFound();
            }
            return View(tRUYEN);
        }

        // GET: TRUYENs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRUYENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDTRUYEN,TENTRUYEN,LINKAVATAR,TACGIA,NOIDUNG,THELOAI,IDUSER,LUOTXEM,LUOTTHEODOI")] TRUYEN tRUYEN)
        {
            if (ModelState.IsValid)
            {
                //tRUYEN.IDUSER = Session["IDUSER"];
                //tRUYEN.TIMEPOST = DateTime.Now;
                db.TRUYENs.Add(tRUYEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRUYEN);
        }

        // GET: TRUYENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRUYEN tRUYEN = db.TRUYENs.Find(id);
            if (tRUYEN == null)
            {
                return HttpNotFound();
            }
            return View(tRUYEN);
        }

        // POST: TRUYENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDTRUYEN,TENTRUYEN,LINKAVATAR,TACGIA,NOIDUNG,THELOAI,LINKTRUYEN,BATDAU,KETTHUC,DUOIANH,IDUSER,LUOTXEM,LUOTTHEODOI")] TRUYEN tRUYEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRUYEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRUYEN);
        }

        // GET: TRUYENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRUYEN tRUYEN = db.TRUYENs.Find(id);

            if (tRUYEN == null)
            {
                return HttpNotFound();
            }
            return View(tRUYEN);
        }

        // POST: TRUYENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRUYEN tRUYEN = db.TRUYENs.Find(id);
            db.TRUYENs.Remove(tRUYEN);
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
