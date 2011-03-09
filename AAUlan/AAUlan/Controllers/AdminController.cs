﻿using System;
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


        #region User
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

            return View("../User/RoleAssignment", viewModel);
        }
        #endregion

        #region Lan

        [HttpGet]
        public ActionResult CreateLan()
        {
            var viewModel = new LanViewModel();

            return View("../Lan/CreateLan",viewModel);
        }

        [HttpPost]
        public ActionResult CreateLan(LanViewModel viewModel)
        {
            repo.AddLan(viewModel.lan);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AllLans()
        {
            var viewModel = repo.GetAllLans();
            return View("../Lan/AllLans", viewModel);
        }
        #endregion

        #region Event
        [HttpGet]
        public ActionResult CreateEvent()
        {
            var viewModel = new Event();

            return View("../Event/Event");
        }

        [HttpPost]
        public ActionResult CreateEvent(Event event1)
        {
            repo.AddEvent(event1);

            return View("../Event/Event");
        }

        [HttpGet]
        public ActionResult AllEvents()
        {
            var viewModel = repo.GetAllEvents();
            return View("../Event/AllEvents", viewModel);
        }
        #endregion

        #region Game
        [HttpGet]
        public ActionResult CreateGame()
        {
            var viewModel = new Games();

            return View("../Game/Game", viewModel);
        }

        [HttpPost]
        public ActionResult CreateGame(Games viewModel)
        {
            repo.AddGame(viewModel);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult AllGames()
        {
            var viewModel = repo.GetAllGames();
            return View("../Game/AllGames", viewModel);
        }
        #endregion
    }
}
