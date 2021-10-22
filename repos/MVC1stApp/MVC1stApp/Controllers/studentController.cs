using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1stApp.Models;
using System.Data.Entity;

namespace MVC1stApp.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        public ActionResult Index()
        {
            using (DbModel dbmodel = new DbModel()) 
            {
                return View(dbmodel.students.ToList());
            }
        }

        // GET: student/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.students.Where(x => x.studentID == id).FirstOrDefault());
            }
        }

        // GET: student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: student/Create
        [HttpPost]
        public ActionResult Create(student st)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    dbmodel.students.Add(st);
                    dbmodel.SaveChanges();

                }
                // TODO: Add insert logic 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.students.Where(x => x.studentID == id).FirstOrDefault());
            }
        }

        // POST: student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, student st)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    dbmodel.Entry(st).State = EntityState.Modified;
                    dbmodel.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: student/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.students.Where(x => x.studentID == id).FirstOrDefault());
            }
        }

        // POST: student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    student st = dbmodel.students.Where(x => x.studentID == id).FirstOrDefault();
                    dbmodel.students.Remove(st);
                    dbmodel.SaveChanges();
                 }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
