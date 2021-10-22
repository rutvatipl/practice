using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Register.Controllers
{
    public class regController : Controller
    {
        // GET: reg
        public ActionResult Index()
        {
            return View();
        }

        // GET: reg/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: reg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reg/Create
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

        // GET: reg/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: reg/Edit/5
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

        // GET: reg/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: reg/Delete/5
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
