using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC1stApp.Models;
using System.Data.Entity;

namespace MVC1stApp.Controllers
{
    public class FamilyController : Controller
    {
        public string Searchby { get; private set; }

        // GET: Family
        public ActionResult Index(string search)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.families.Where(emp => emp.member == search || search == null).ToList());
            }
        }

        // GET: Family/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.families.Where(x => x.memberid == id).FirstOrDefault());
            }
        }

        // GET: Family/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Family/Create
        [HttpPost]
        public ActionResult Create(family familys)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    dbmodel.families.Add(familys);
                    dbmodel.SaveChanges();

                }
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Family/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.families.Where(x => x.memberid == id).FirstOrDefault());
            }
        }

        // POST: Family/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, family familys)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    dbmodel.Entry(familys).State = EntityState.Modified;
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

        // GET: Family/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel dbmodel = new DbModel())
            {
                return View(dbmodel.families.Where(x => x.memberid == id).FirstOrDefault());
            }
        }

        // POST: Family/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModel dbmodel = new DbModel())
                {
                    family familys = dbmodel.families.Where(x => x.memberid == id).FirstOrDefault();
                    dbmodel.families.Remove(familys);
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
