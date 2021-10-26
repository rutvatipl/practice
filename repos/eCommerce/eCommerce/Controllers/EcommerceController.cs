﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;

namespace ECommerceSite.Controllers
{
    public class ecommerceController : Controller
    {
        // GET: ecommerce
        public ActionResult Index()
        {
            using (DBmodel db = new DBmodel())
            {


                return View(db.customer_reg.ToList());
            }
        }

        // GET: ecommerce/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ecommerce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ecommerce/Create
        [HttpPost]
        public ActionResult Create(customer_reg cust)
        {
            try
            {
                using (DBmodel db = new DBmodel())
                {


                    db.customer_reg.Add(cust);
                    db.SaveChanges();
                }

                return RedirectToAction("CreateUserLogin");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateLogin()
        {
            return View();
        }

        //POST: ecommerce/Create


        public ActionResult CreateUserLogin()
        {
            return View();
        }

        // POST: ecommerce/Create
        [HttpPost]
        public ActionResult CreateUserLogin(customer_reg reg)
        {
            try
            {
                using (DBmodel db = new DBmodel())
                {

                    if (ModelState.IsValid)
                    {
                        db.customer_reg.Add(reg);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }

                // return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: ecommerce/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ecommerce/Edit/5
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

        // GET: ecommerce/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ecommerce/Delete/5
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
        //public ActionResult NewProduct()
        //{
        //    return View();
        //}

        // POST: aadmin/Create
      
        public ActionResult NewProduct()
        {

          
                using (DBmodel db = new DBmodel())
                {
                   return View( db.products.ToList());
                 
                }

          
        }
        public ActionResult AddtoCart(int productid)
        {
            DBmodel db = new DBmodel();
            List<item> cart = new List<item>();
            var prod = db.products.Find(productid);
            cart.Add(new item()
            {
                pro = prod,
                quantity = 1
            });
            Session["cart"] = cart;


                return Redirect("Index");
        }
    }
}