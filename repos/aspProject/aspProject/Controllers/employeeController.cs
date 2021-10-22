using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspProject.Models;

namespace aspProject.Controllers
{
    public class employeeController : Controller
    {
        // GET: employee
        public ActionResult Index()
        {
            using (DBmodel dbmodel = new DBmodel())
            {
                return View(dbmodel.employees);
            }
        }
        // GET: employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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
