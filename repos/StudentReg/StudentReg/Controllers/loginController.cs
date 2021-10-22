using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentReg.Models;
using PagedList.Mvc;
using PagedList;




namespace loging.Content
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index(int? page)
        {
            //using (DbModel db = new DbModel())
            //{
            //    return View(db.Loginforms.ToList());
            //}
            using (DbModel db = new DbModel())
            {
                int pagesize = 2, pageindex = 1;
                pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
                var list = db.Loginforms.ToList();
                IPagedList<Loginform> stu = list.ToPagedList(pageindex, pagesize);
                return View(stu);
            }

        }

        // GET: login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: login/Create
        [HttpPost]
        public ActionResult Create(Loginform lg)
        {
            try
            {
                using (DbModel db = new DbModel())
                {
                    db.Loginforms.Add(lg);
                    db.SaveChanges();
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: login/Edit/5
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

        // GET: login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: login/Delete/5
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
