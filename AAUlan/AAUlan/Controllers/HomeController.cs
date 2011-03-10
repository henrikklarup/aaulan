using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAUlan.Models;
using AAUlan.ViewModels;

namespace AAUlan.Controllers
{
    public class HomeController : Controller
    {

        DatabaseReposity repo = new DatabaseReposity();

        #region Index
        #region GET
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new EventViewModel();
            try
            {
                int id = repo.GetCurrentLan().ID;

                viewModel.events = repo.GetAllFutureEvents(id).ToList();
            }
            catch
            {
            }

            return View(viewModel);
        }
        #endregion
        #endregion
    }
}
