using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCS.MvcWeb.Entity;
using BCS.MvcWeb.Identity;
using BCS.MvcWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace BCS.MvcWeb.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();
            
        private UserManager<AplicationUser> userManager;
        private RoleManager<AplicationRole> roleManager;

        
        public AccountController()
        {
            var usrStore = 
                new UserStore<AplicationUser>(new IdentityDataContext());
            userManager = new UserManager<AplicationUser>(usrStore);

            var roleStore = new RoleStore<AplicationRole>(new IdentityDataContext());
            roleManager = new RoleManager<AplicationRole>(roleStore);
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders
                .Where(i => i.UserName == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    Total = i.Total
                }).OrderByDescending(i=>i.OrderDate).ToList();


            return View(orders);
        }
        [Authorize]
        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a=>new OrderLineModel()
                    {
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name.Length>50?a.Product.Name.Substring(0,47)+"...":a.Product.Name,
                        Image = a.Product.Image,
                        Quantity = a.Quantity,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register Model)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemleri

                var user = new AplicationUser();
                user.Name = Model.Name;
                user.Surname = Model.Surname;
                user.Email = Model.Email;
                user.UserName = Model.UserName;


                 IdentityResult result= userManager.Create(user, Model.Password);

                 if (result.Succeeded)
                 {
                     //kullanıcı oluştu ve kullanıcıyı bir role atabilirsiniz.
                     if(roleManager.RoleExists("user"))
                     {
                         userManager.AddToRole(user.Id, "user");
                     }

                     return RedirectToAction("Login", "Account");

                 }
                 else
                 {
                     ModelState.AddModelError("RegisterUserEror","Kullanıcı oluşturma hatası.");
                 }

            }

            return View(Model);
        }




        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login Model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //Login İşlemleri
                var  user = userManager.Find(Model.UserName, Model.Password);

                if (user!= null)
                {
                   //varolan kullanıcıyı sisteme dahil et.
                   //AplicationCookie oluşturup sisteme bırak

                   var authManager = HttpContext.GetOwinContext().Authentication;
                   var identityclaims = userManager.CreateIdentity(user, "AplicationCookie");
                   var authProperties = new AuthenticationProperties();
                   authProperties.IsPersistent = Model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                       return Redirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserEror", "Böyle bir kullanıcı yok.");
                }



            }

            return View(Model);
        }


        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }


    }
}