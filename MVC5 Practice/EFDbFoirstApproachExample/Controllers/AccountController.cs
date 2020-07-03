using EFDbFoirstApproachExample.Identity;
using TrentBas.DomainModels.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EFDbFoirstApproachExample.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [ActionName("Register")]
        public ActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if(ModelState.IsValid)
            {
                var appDbContext = new ApplicationDbContext();
                var userStore = new ApplicationUserStore(appDbContext);
                var userManager = new ApplicationUserManager(userStore);
                var passwordHash = Crypto.HashPassword(rvm.Password);
                var user = new ApplicationUser()
                {
                    Email = rvm.Email,
                    UserName = rvm.Username,
                    PasswordHash = passwordHash,
                    City = rvm.City,
                    Country = rvm.Country,
                    Birthday = rvm.DateOfBirth,
                    Address = rvm.Address,
                    PhoneNumber = rvm.Mobile
                };

                IdentityResult result = userManager.Create(user);

                if(result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");

                    var authenticationManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("My Error", "Invalid Data");
                return View();
            }
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Login(LoginViewModel lvm)
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            var user = userManager.Find(lvm.Username, lvm.Password);

            if(user!=null)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);

                if (userManager.IsInRole(user.Id,"Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else if (userManager.IsInRole(user.Id, "Manager"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }                
            }
            else
            {
                ModelState.AddModelError("Myerror", "Invalid username or password");
                return View();
            }
            
        }

        [NonAction]
        public void LoginUser(ApplicationUserManager userManager,ApplicationUser user)
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties(), userIdentity);
        }

        public ActionResult Logout()
        {
            var authenicationManager = HttpContext.GetOwinContext().Authentication;
            authenicationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MyProfile()
        {
            var appDbContext = new ApplicationDbContext();
            var userStore = new ApplicationUserStore(appDbContext);
            var userManager = new ApplicationUserManager(userStore);
            ApplicationUser appUser = userManager.FindById(User.Identity.GetUserId());
            return View(appUser);
        }
    }
}