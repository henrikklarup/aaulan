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

        #region Index
        #region GET
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        #endregion

        #region User
        #region RoleAssignment
        #region GET
        [HttpGet]
        [Authorize(Roles="Administrator, Crew")]
        public ActionResult RoleAssignment()
        {
            var viewModel = new UserViewModel()
            {
                users = repo.GetAllUsers().ToList()
            };

            return View("../User/RoleAssignment",viewModel);
        }
        #endregion
        #endregion

        #region PromoteOrDemote
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator")]
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
                default:
                    break;
            }
            return View();
        }
        #endregion
        #endregion

        #region SearchUsername
        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult SearchUsername(string Username)
        {
            var viewModel = new UserViewModel()
            {
                users = repo.GetUsersByUsername(Username).ToList()
            };

            return View("../User/RoleAssignment", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region Lan

        #region CreateLan
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateLan()
        {
            var viewModel = new LanViewModel();

            return View("../Lan/CreateLan",viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateLan(LanViewModel viewModel)
        {
            repo.AddLan(viewModel.lan);

            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion

        #region AllLans
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllLans()
        {
            var viewModel = repo.GetAllLans();
            return View("../Lan/AllLans", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region Event
        #region CreateEvent
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateEvent()
        {
            var viewModel = new Event();

            return View("../Event/Event");
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateEvent(Event event1)
        {
            repo.AddEvent(event1);

            return View("../Event/Event");
        }
        #endregion
        #endregion

        #region DeleteEvent
        #region GET
        [HttpGet]
        public ActionResult DeleteEvent(int id)
        {
            repo.DeleteEvent(id);
            return RedirectToAction("AllEvents","Admin");
        }
        #endregion
        #endregion

        #region AllEvents
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllEvents()
        {
            var viewModel = repo.GetAllEvents();
            return View("../Event/AllEvents", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region Game
        #region CreateGame
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateGame()
        {
            var viewModel = new Games();

            return View("../Game/Game", viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult CreateGame(Games viewModel)
        {
            if (viewModel.Name == null)
                ModelState.AddModelError("Name", "Name must be valid");
            else
            {
                repo.AddGame(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
        #endregion

        #region AllGames
        #region GET
        [HttpGet]
        public ActionResult AllGames()
        {
            var viewModel = repo.GetAllGames();
            return View("../Game/AllGames", viewModel);
        }
        #endregion
        #endregion
        #endregion
    }
}
