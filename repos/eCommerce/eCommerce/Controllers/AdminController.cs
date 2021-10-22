using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using eCommerce.repository;
using Newtonsoft.Json;

namespace eCommerce.Controllers
{
    public class AdminController : Controller
    {
      public GenericRepositoryWork Genericwork = new GenericRepositoryWork();
        
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Category()
        {
            List<category> allcategories = Genericwork.GetRepositoryInstance<category>().GetAllRecodsIQuryable().ToList();
            return View(allcategories);
        }
        public ActionResult AddCategory()
        {
            return UpdateCategory(0);
        }
     
        public ActionResult UpdateCategory(int categoryid)
        {
            CategoryDetails cd;
            if (categoryid != null)
            {
                cd=JsonConvert.DeserializeObject<CategoryDetails>(JsonConvert.SerializeObject(Genericwork.GetRepositoryInstance<category>().GetFirstOrDeafault(categoryid)));
            }
                else
            {
                cd = new CategoryDetails();
            }
            return View("UpdateCategory", cd);
        }
        public ActionResult Product()
        {
            return View(Genericwork.GetRepositoryInstance<product>().Getproduct());
        }
     
        public ActionResult ProductEdit(int productId)
        {
            return View(Genericwork.GetRepositoryInstance<product>().GetFirstOrDeafault(productId));
        }
        [HttpPost]
        public ActionResult ProductEdit(product tbl)
        {
            Genericwork.GetRepositoryInstance<product>().Update(tbl);
            return RedirectToAction("product");
        }
    }
}