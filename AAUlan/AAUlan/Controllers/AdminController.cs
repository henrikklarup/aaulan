using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAUlan.Models;
using AAUlan.ViewModels;

namespace AAUlan.Controllers
{
    public class AdminController : Controller
    {
        DatabaseReposity repo = new DatabaseReposity();

        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RoleAssignment()
        {
            var viewModel = new UserViewModel()
            {
                users = repo.GetAllUsers().ToList()
            };

            return View("../User/RoleAssignment",viewModel);
        }

        [HttpPost]
        public ActionResult PromoteOrDemote(string submitButton, string Username)
        {
            switch (submitButton)
            {
                case "Promote":
                    repo.Promote(Username);
                    return RedirectToAction("RoleAssignment");
                case "Demote":
                    repo.Demote(Username);
                    return RedirectToAction("RoleAssignment");
                case "Change":
                    return RedirectToAction("ModeratorStatus", new { user = repo.GetUserFromUsername(Username) });
                default:
                    break;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SearchUsername(string Username)
        {
            var viewModel = new UserViewModel()
            {
                users = repo.GetUsersByUsername(Username).ToList()
            };

            return View("RoleAssignment", viewModel);
        }


        [HttpGet]
        public ActionResult CreateLan()
        {
            var viewModel = new LanViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateLan(LanViewModel viewModel)
        {


            return View(viewModel);
        }
    }
}
