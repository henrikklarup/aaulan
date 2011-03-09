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
            viewModel.mad.Number = viewModel.mad.NUM;
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
                viewModel.x= "Confirmed - Now go paid asshole!";
            else
                viewModel.x = "Denied - Either you suck, or the crew does";

            return View(viewModel);
        }


        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrders()
        {
            var viewModel = new OrderViewModel()
            {
                Orders = repo.GetAllOrders().ToList()
            };
            return View("../Order/AllOrders", viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrders(OrderViewModel viewModel)
        {
            repo.UpdateOrders(viewModel.Orders);
            return RedirectToAction("AllOrders");
        }

        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrdersWithId(int id)
        {
            var viewModel = repo.GetAllOrdersWithId(id);
            return View("../Order/AllOrders", viewModel);
        }
    }
}
