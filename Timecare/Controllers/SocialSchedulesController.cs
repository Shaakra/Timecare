﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Timecare.Models;

namespace Timecare.Controllers
{
    public class SocialSchedulesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SocialSchedules
        public ActionResult Index()
        {
            return View(db.SocialSchedules.ToList());
        }

        // GET: SocialSchedules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialSchedule socialSchedule = db.SocialSchedules.Find(id);
            if (socialSchedule == null)
            {
                return HttpNotFound();
            }
            return View(socialSchedule);
        }

        // GET: SocialSchedules/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartTime,EndTime")] SocialSchedule socialSchedule)
        {
            if (ModelState.IsValid)
            {
                db.SocialSchedules.Add(socialSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialSchedule);
        }

        // GET: SocialSchedules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialSchedule socialSchedule = db.SocialSchedules.Find(id);
            if (socialSchedule == null)
            {
                return HttpNotFound();
            }
            return View(socialSchedule);
        }

        // POST: SocialSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartTime,EndTime")] SocialSchedule socialSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialSchedule);
        }

        // GET: SocialSchedules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialSchedule socialSchedule = db.SocialSchedules.Find(id);
            if (socialSchedule == null)
            {
                return HttpNotFound();
            }
            return View(socialSchedule);
        }

        // POST: SocialSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialSchedule socialSchedule = db.SocialSchedules.Find(id);
            db.SocialSchedules.Remove(socialSchedule);
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
