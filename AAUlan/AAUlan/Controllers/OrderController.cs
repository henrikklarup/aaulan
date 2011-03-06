using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AAUlan.ViewModels;

namespace AAUlan.Controllers
{
    public class OrderController : Controller
    {


        //
        // GET: /Order/
        public ActionResult Index()
        {
            var viewModel = new OrderViewModel();
            return View(viewModel);
        }

    }
}
