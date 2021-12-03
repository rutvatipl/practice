using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using eCommerce.Models;

namespace ECommerceSite.Controllers
{
    public class ecommerceController : Controller
    {
        [Authorize]
        // GET: ecommerce
        public ActionResult Index()
        {
            using (DBmodel db = new DBmodel())
            {


                return View(db.products.ToList());
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "IsEmailVerified,ActivationCode")] customer_reg reg)
        {
            bool Status = false;
            String message = "";

            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(reg.email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email is allraedy Exist");
                    return View(reg);
                }

                #region Generate Activation Code
                reg.ActivationCode = Guid.NewGuid();
                #endregion

                #region Password Hashing
                reg.password = Crypto.Hash(reg.password);
                reg.cpassword = Crypto.Hash(reg.cpassword);
                #endregion
                reg.IsEmailVerified = false;


                #region Save To Database
                using (DBmodel db = new DBmodel())
                {
                    db.customer_reg.Add(reg);
                  
                    db.SaveChanges();
                    

                    

                    //Send Email to User
                    SendVarificationLinkEmail(reg.email, reg.ActivationCode.ToString());
                    message = "Registration successfully done. Account activation link " +
                        " has been sent to your email id:" + reg.email;
                    Status = true;
                }
                #endregion

                #region Save to Database
                using (DBmodel db = new DBmodel())
                {
                    db.customer_reg.Add(reg);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                    //db.customer_reg.Add(reg);
                    //db.SaveChanges();

                    SendVarificationLinkEmail(reg.email, reg.ActivationCode.ToString());
                    message = "Registration successfully done.Account activation link" +
                        "has been sent to your email id:" + reg.email;
                    Status = true;
                }
                #endregion

            }
            else
            {
                message = "InValid Requst";
            }
            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(reg);
            //try
            //{
            //    using (DBmodel db = new DBmodel())
            //    {


            //        db.customer_reg.Add(cust);
            //        db.SaveChanges();
            //    }

            //    return RedirectToAction("CreateUserLogin");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        [HttpGet]
        public ActionResult VarifyAccount(string id)
        {
            bool Status = false;
            using(DBmodel db = new DBmodel())
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                var v = db.customer_reg.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if(v != null)
                {
                    v.IsEmailVerified = true;
                    db.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        

        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("CreateLogin", "Ecommerce");
        }
        [HttpGet]
        public ActionResult CreateLogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLogin(rem login, string ReturnUrl)
        {
            string message = "";
            using (DBmodel db = new DBmodel())
            {
                var v = db.customer_reg.Where(a => a.email == login.email).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(Crypto.Hash(login.password), v.password) == 0)
                    {
                        int timeout = login.remember ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(login.email, login.remember, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Ecommerce");
                        }
                    }
                    else
                    {
                        message = "Invalid";
                    }

                }
                else
                {
                    message = "Invalid";
                }
            }
            ViewBag.Message = message;
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
       
        //public ActionResult NewProduct()
        //{
        //    return View();
        //}

        // POST: aadmin/Create

        public ActionResult NewProduct()
        {


            using (DBmodel db = new DBmodel())
            {
                return View(db.products.ToList());

            }


        }
        public ActionResult AddtoCart(int ?id)
        {
            using (DBmodel db = new DBmodel())
            {
                //var v = db.products.Where(a => a.p_id == id).FirstOrDefault();
                //return View(v);
                return View(db.products.Where(x => x.p_id == id).FirstOrDefault());
            }
           
        }
        List<cart> li = new List<cart>();
        [HttpPost]
        public ActionResult AddtoCart(product p_id, string quantity, int id)
        {
            using (DBmodel db = new DBmodel())
            {
                var v = db.products.Where(a => a.p_id == id).FirstOrDefault();

                cart c = new cart();
                c.product_id = v.p_id;
                c.price = v.product_price;
                c.quantity = Convert.ToInt32(quantity);
                c.bill = c.price * c.quantity;


                if (TempData["cart"] == null)
                {
                    li.Add(c);
                    TempData["cart"] = li;

                }
                else
                {
                    List<cart> li2 = TempData["cart"] as List<cart>;
                    li2.Add(c);
                    TempData["cart"] = li2;
                }

                TempData.Keep();
                return RedirectToAction("product");
            }

        }
        [HttpGet]
        public ActionResult registration()
        {
            return View();
        }
        
       
        [NonAction]
        public bool IsEmailExist(String emailid)
        {
            using (DBmodel db = new DBmodel())
            {
                var v = db.customer_reg.Where(a => a.email == emailid).FirstOrDefault();
                return v != null;
            }
        }
        [NonAction]
        public void SendVarificationLinkEmail(String emailid, String activationCode,String emailFor = "Varifyaccount")
        {
            var verifyUrl = "/Ecommerce/"+ emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            var FromEmail = new MailAddress("tathyainfotechtest@gmail.com", "DotNet Awesome");
            var toemail = new MailAddress(emailid);
            var fromemailpassword = "Tipl@12345!";
            

            string subject = "";
            string body = "";
            if (emailFor == "Varifyaccount")
            {
                subject = "your account is successfully created!";
                 body = "<br/><br/>We are exsited to tell you that your DotNet Awesome Account is" +
               "Successfully Created.Please Clickon the belowe link to varify Your account" +
               "<br/><br/><a href='" + link + "'>" + link + "</a>";
            }
            else if(emailFor =="ResetPassword")
                {
                subject = "ResetPassword";
                body = "<br/><br/>click blelow link and reset password" +
                    "<br/><br/><a href='" + link + "'>Reset Password</a>";
            }

           

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromEmail.Address, fromemailpassword)

            };
            using (var Message = new MailMessage(FromEmail, toemail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            })
                smtp.Send(Message);



        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(String Email)
        {
            String message = "";
            bool Status = false;
            using (DBmodel db = new DBmodel())
            {
                var account = db.customer_reg.Where(a => a.email == Email).FirstOrDefault();
                if(account != null)
                {
                    String resetCode = Guid.NewGuid().ToString();
                    SendVarificationLinkEmail(account.email, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    message = "Reset password link has been sent to your email id";
                }
                else
                {
                    message = "account is not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(String id)
        {
            using (DBmodel db = new DBmodel())
            {
                var account = db.customer_reg.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (account != null)
                {
                    ResetPassword model = new ResetPassword();
                    model.ResetPasswordCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                } 
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPassword reset)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (DBmodel db = new DBmodel())
                {
                    var user = db.customer_reg.Where(a => a.ResetPasswordCode == reset.ResetPasswordCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.password = Crypto.Hash(reset.cpassword);
                        user.ResetPasswordCode = "";
                        db.Configuration.ValidateOnSaveEnabled = false;
                        db.SaveChanges();
                        message = "New password successfully";
                    }
                   
                }

            }
            else
            {
                message = "Somthing is invalid";
            }
            ViewBag.Message = message;
            return View(reset);
        }
    }
}

