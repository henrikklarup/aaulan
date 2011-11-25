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

        #region Index
        #region GET
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new OrderViewModel();
            return View(viewModel);
        }
        #endregion

        #region POST
        [HttpPost]
        public ActionResult Index(OrderViewModel viewModel)
        {
            if (viewModel.mad.Name == null|| viewModel.mad.Name == string.Empty)
                return RedirectToAction("Status", new { status = 3 });

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
        #endregion
        #endregion

        #region Status
        #region GET
        [HttpGet]
        public ActionResult Status(int status)
        {
            var viewModel = new Mad();

            if (status == 0)
                viewModel.x= "Confirmed - SKAL BETALES - NU!";
            else if(status == 1)
                viewModel.x = "Denied - There is no such event";
            else if(status == 2)
                viewModel.x = "Denied - Out of range exeption";
            else if (status == 3)
                viewModel.x = "Denied - Motherfucker haz name?!";

            return View(viewModel);
        }
        #endregion
        #endregion

        #region AllOrders
        #region GET
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
        #endregion

        #region POST
        [HttpPost]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrders(OrderViewModel viewModel)
        {
            repo.UpdateOrders(viewModel.Orders);
            return RedirectToAction("AllOrders");
        }
        #endregion

        #region AllOrdersWith ID
        #region GET
        [HttpGet]
        [Authorize(Roles = "Administrator, Crew")]
        public ActionResult AllOrdersWithId(int id)
        {
            OrderViewModel viewModel = new OrderViewModel();
            viewModel.Orders = repo.GetAllOrdersWithId(id).ToList<Mad>();
            return View("../Order/AllOrders", viewModel);
        }
        #endregion
        #endregion
        #endregion

        #region DeleteOrder
        #region GET
        [HttpGet]
        public ActionResult DeleteOrder(int id)
        {
            repo.DeleteOrder(id);
            return RedirectToAction("AllOrders");
        }
        #endregion
        #endregion

        #region GetTotalOrders
        #region GET
        [HttpGet]
        public ActionResult GetTotalOrder(int id)
        {
            List<Mad> allFood = repo.GetAllOrdersWithId(id).OrderBy(s => s.Number).ToList();
            List<Mad> totalFood = new List<Mad>();
            List<int> checkedIds = new List<int>();

            if (allFood.Count != 0)
            {
                for (int i = 0; i < allFood.Count; i++)
                {
                    int count = 1;
                    for (int x = i + 1; x < allFood.Count; x++)
                    {
                        if (allFood[i].Number == allFood[x].Number && allFood[i].Note.ToLower() == allFood[x].Note.ToLower())
                        {
                            count++;
                            checkedIds.Add(x);
                        }
                    }
                    if (!checkedIds.Contains(i))
                    {
                        Mad newMad = allFood[i];
                        newMad.quantity = count;
                        totalFood.Add(newMad);
                    }
                }
            }

            /*
            for (int i = 0; i <= allFood.Count -1; i++)
            {
                int count = 1;
                for (int x = i + 1; x < allFood.Count; x++)
                {
                    if (allFood[i].Number == allFood[x].Number && allFood[i].Note.ToLower() == allFood[x].Note.ToLower())
                    {
                        count++;
                    }
                }
                Mad newMad = allFood[i];
                newMad.quantity = count;
                totalFood.Add(newMad);
            }*/

            var viewModel = new OrderViewModel
            {
                Orders = totalFood
            };

            return View("GetTotalOrder", viewModel);
        }
        #endregion
        #endregion
    }
}
