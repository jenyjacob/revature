using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Library;
using PizzaStore.WebUI.Models;

namespace PizzaStore.WebUI.Controllers
{
    public class CustomerController : Controller
    {

        public IStoreRepo Repo { get; }

        public CustomerController(IStoreRepo repo) =>
            Repo = repo ?? throw new ArgumentNullException(nameof(repo));
        // GET: Customer
        public ActionResult Index([FromQuery] string search ="")
        {
            IEnumerable<Customer> customer = Repo.GetCustomer(search);
            IEnumerable<CustomerViewModel> viewModels = customer.Select(x => new CustomerViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
              //  Orders = x.PurOrder.Select(y => new CustomerViewModel()),

            }

            );
            return View(viewModels);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        PhoneNumber = viewModel.PhoneNumber
                    };
                    Repo.AddCustomer(customer);
                    Repo.Save();

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}