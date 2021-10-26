using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;

namespace eCommerce.Controllers
{
    public class aadminController : Controller
    {

        // GET: aadmin
        public ActionResult dashboard()
        {
            return View();
        }

        // GET: aadmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult categoty(string option, string search)
        {
            using (DBmodel db = new DBmodel())
            {
                if (option == "category_name")
                {
                    //Index action method will return a view with a student records based on what a user specify the value in textbox  
                    return View(db.categories.Where(x => x.category_name == search || search == null).ToList());
                }
                else if (option == "catrgory_name")
                {
                    return View(db.categories.Where(x => x.category_name == search || search == null).ToList());
                }
                else
                {
                    return View(db.categories.ToList());
                }
            }

        }
        // GET: aadmin/Create
        public ActionResult CreateCategory()
        {
            return View();
        }

        // POST: aadmin/Create
        [HttpPost]
        public ActionResult CreateCategory(category cat)
        {
            try
            {
                using (DBmodel db = new DBmodel())
                {
                    db.categories.Add(cat);
                    db.SaveChanges();
                }

                return RedirectToAction("categoty");
            }
            catch
            {
                return View();
            }
        }

        // GET: aadmin/Edit/5
        public ActionResult EditCategory(int id)
        {
            using (DBmodel db = new DBmodel())
            {
                return View(db.categories.Where(x=>x.category_id==id).FirstOrDefault());
            }
        }

        // POST: aadmin/Edit/5
        [HttpPost]
        public ActionResult EditCategory(int id, category cat)
        {
            try
            {
                using (DBmodel db = new DBmodel())
                {
                    db.Entry(cat).State = EntityState.Modified;
                    db.SaveChanges();

                }
                    // TODO: Add update logic here

                    return RedirectToAction("categoty");
            }
            catch
            {
                return View();
            }
        }

        // GET: aadmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: aadmin/Delete/5
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
        public ActionResult product(string option, string search)
        {
            DBmodel db = new DBmodel();
            //if a user choose the radio button option as Subjec  
            if (option == "p_name")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(db.products.Where(x => x.p_name == search || search == null).ToList());
            }

            else
            {
                return View(db.products.Where(x => x.p_desc.StartsWith(search) || search == null).ToList());
            }
        }
      
        // GET: aadmin/Create
        public ActionResult CreateProduct()
        {
            return View();
        }

        // POST: aadmin/Create
        [HttpPost]
        public ActionResult CreateProduct(product pro, HttpPostedFileBase file)
        {

            try
            {
                
                using (DBmodel db = new DBmodel())
                {
                    db.products.Add(pro);
                    db.SaveChanges();
                }

                return RedirectToAction("product");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(product img)
        {
            return View();
        }

        // GET: aadmin/Edit/5
        public ActionResult Editproduct(int id)
        {
            using (DBmodel db = new DBmodel())
            {
                return View(db.products.Where(x => x.p_id == id).FirstOrDefault());
            }
        }

        // POST: aadmin/Edit/5
        [HttpPost]
        public ActionResult Editproduct(int id, category cat)
        {
            try
            {
                using (DBmodel db = new DBmodel())
                {
                    db.Entry(cat).State = EntityState.Modified;
                    db.SaveChanges();

                }
                // TODO: Add update logic here

                return RedirectToAction("product");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Loginadmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loginadmin(Login objUser)
        {
            if (ModelState.IsValid)
            {
                using (DBmodel db = new DBmodel())
                {
                    var obj = db.Logins.Where(a => a.email.Equals(objUser.email) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["email"] = obj.email.ToString();
                        Session["password"] = obj.password.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["email"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Loginadmin");
            }
        }

    }
}