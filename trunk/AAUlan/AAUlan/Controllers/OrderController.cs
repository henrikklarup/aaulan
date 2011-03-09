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
            viewModel.mad.Paid = false;
            bool accepted = repo.AddOrder(viewModel.mad);

            if (accepted)
                return RedirectToAction("Status", new { status = true });
            else
                return RedirectToAction("Status", new { status = false });
        }

        [HttpGet]
        public ActionResult Status(bool status)
        {
            var viewModel = new Mad();

            if (status)
                viewModel.x= "Confirmed";
            else
                viewModel.x = "Denied";

            return View(viewModel);
        }
    }
}
