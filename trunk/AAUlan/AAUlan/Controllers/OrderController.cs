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
            if (viewModel.mad.Number < 1 || viewModel.mad.Number > 90)
            {
                return RedirectToAction("Status", new { status = 2 });
            }
            viewModel.mad.Number = viewModel.mad.Number;
            viewModel.mad.Paid = false;
            bool accepted = repo.AddOrder(viewModel.mad);

            if (accepted)
                return RedirectToAction("Status", new { status = 0 });
            else
                return RedirectToAction("Status", new { status = 1 });
        }

        [HttpGet]
        public ActionResult Status(int status)
        {
            var viewModel = new Mad();

            if (status == 0)
                viewModel.x= "Confirmed - SKAL BETALES - NU!";
            else if(status == 1)
                viewModel.x = "Denied - There is no such event";
            else if(status == 2)
                viewModel.x = "Denied - Out range exeption";

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
