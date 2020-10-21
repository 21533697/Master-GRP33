using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyBookingRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class SuperAdminController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext context;


        public SuperAdminController()
        {
            context = new ApplicationDbContext();
        }

        public SuperAdminController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;

        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: SuperAdmin
        public ActionResult Index()
        {
            return View();
        }

        //StatusIndex
        public ActionResult StatusIndex()
        {
            return View();
        }
        
        // GET: SuperAdmin
        public ActionResult SuperAdminProfile()
        {
            return View();
        }

        // POST: /Account/Register/DeliverySystem
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string cust = "Delivery";

                var user = new ApplicationUser { Name = cust, UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await UserManager.AddToRolesAsync(user.Id, cust);
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link


                    //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    //await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    //Please Changed this redirect Copy code from booking/Register New Artist
                    return RedirectToAction("Index", "AppUsers");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //Customer List
        public ActionResult customerIndex()
        {
            var myArtisys = context.Users.Where(b => b.Name == "Customer").ToList();
            return View(myArtisys);
        }

        public ActionResult DeliverySystemIndex()
        {
            var myArtisys = context.Users.Where(b => b.Name == "Delivery").ToList();
            return View(myArtisys);
        }

        public ActionResult InventoryIndex()
        {

            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }









        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}