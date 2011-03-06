using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAUlan.Models;
using AAUlan.ViewModels;

namespace AAUlan.Controllers
{
    public class OrderController : Controller
    {
        DatabaseReposity repo = new DatabaseReposity();

        //
        // GET: /Order/
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new OrderViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(OrderViewModel viewModel)
        {
            viewModel.pizza.Paid = false;
            bool accepted = repo.AddOrder(viewModel.pizza);

            if (accepted)
                return View("Status", new { status = true });
            else
                return View("Status", new { status = false });
        }

        [HttpGet]
        public ActionResult Status(bool status)
        {
            if (status)
                ViewData["Message"] = "Confirmed";
            else
                ViewData["Message"] = "Denied";

            return View();
        }
    }
}
