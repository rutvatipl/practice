using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc.Models;
using System.Net.Http;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeMvc
        public ActionResult Index()
        {
            IEnumerable<MvcEmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<MvcEmployeeModel>>().Result;
            return View(empList);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id ==0)
            {
                return View(new MvcEmployeeModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("employee/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MvcEmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MvcEmployeeModel emp)
        {
            if (emp.e_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("employee", emp).Result;
                TempData["SuccessMessage"] = "Save Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("employee/"+ emp.e_id, emp).Result;
                TempData["SuccessMessage"] = "Update Successfully";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}