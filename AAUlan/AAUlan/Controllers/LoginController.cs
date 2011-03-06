using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using AAUlan.Models;

namespace AAUlan.Controllers
{
    public class LoginController : Controller
    {
        #region Properties
        //Repository for making database requests
        DatabaseReposity repo = new DatabaseReposity();
        #endregion

        #region Login
        #region GET
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region POST
        /// <summary>
        /// POST: /Login/Login
        /// Login the user to the system
        /// </summary>
        /// <param name="Username">Username</param>
        /// <param name="Password">Password</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(User user)
        {
            //Encrypt password to MD5
            string epas = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");

            //Check if user is valid in the system
            if (repo.ValidateUser(user.Username, epas))
            {
                //Assign user role, from system
                string role = repo.GetUserRoleFromUsername(user.Username);

                //Assign Form Authentication
                #region FormAuthentication
                FormsAuthentication.Initialize();
                FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1,
                    user.Username,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(30),
                    false,
                    role,
                    FormsAuthentication.FormsCookiePath);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,
                    FormsAuthentication.Encrypt(fat)));
                #endregion
            }


            //Return to request page
            return Redirect(FormsAuthentication.GetRedirectUrl(user.Username, false));


            //Never Used   //
            //Return /Home/Index
            Response.Redirect("/Home", true);
            return View();
            //-------------//
        }
        #endregion
        #endregion

        #region Logout
        #region POST
        /// <summary>
        /// Logout from the system
        /// </summary>
        /// <returns>Return to Index Page</returns>
        [HttpPost]
        public ActionResult Logout()
        {
            //Abandon Session
            Session.Abandon();
            //Signout form forms authentication
            FormsAuthentication.SignOut();
            //Redirect to ./Home/Index
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion

        #region Create User
        #region GET
        /// <summary>
        /// GET: /Login/Create
        /// </summary>
        /// <returns>Returns /Login/Create</returns>
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new User();

            return View(viewModel);
        }
        #endregion

        #region POST
        /// <summary>
        /// POST: /Login/Create
        /// Encrypts the password with MD5 and Adds the user to the database
        /// </summary>
        /// <param name="user">User data from view</param>
        /// <returns>Returns /Home/Index</returns>
        [HttpPost]
        public ActionResult Create(User user)
        {
            //Encrypt Password With MD5
            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");

            //Set to lower role
            user.Role = "Administrator";

            //Add User to database
            repo.AddUser(user);

            //Return to /Home/Index
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion
    }
}
