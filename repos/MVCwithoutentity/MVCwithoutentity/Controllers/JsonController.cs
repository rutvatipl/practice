using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using MVCwithoutentity.Models;


namespace MVCwithoutentity.Controllers
{
    public class JsonController : Controller
    {
        // GET: Json
        database.db db1 = new database.db();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult get_data()
        {
            DataSet ds = db1.Show_data();
            List<Json> listreg = new List<Json>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreg.Add(new Json
                {
                  
                    name = dr["name"].ToString(),
                    email = dr["email"].ToString(),
                    gender = dr["gender"].ToString(),
                    dob = Convert.ToDateTime(dr["dob"])
                });
            }
            return Json(listreg, JsonRequestBehavior.AllowGet);
        }
      

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Json/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Json/Create
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

        // GET: Json/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Json/Edit/5
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

        // GET: Json/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Json/Delete/5
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
