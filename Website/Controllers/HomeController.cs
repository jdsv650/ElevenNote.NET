using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public bool AddUsersToRoles()
        {
            IdentityDbContext identityContext = new IdentityDbContext();


            var user = identityContext.Users.Where(u => u.UserName.Equals("jdsv650.utest1@gmail.com", StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault();
            var account = new AccountController();

            account.UserManager.AddToRoleAsync(user.Id, "Admin");


            return true;
        }




    }
}