using CoffeeShopMVC.DataAccess;
using Microsoft.AspNetCore.Mvc;
using CoffeeShopMVC.Models;

namespace CoffeeShopMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CoffeeShopMVCContext _context;

        public CustomersController(CoffeeShopMVCContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var customers = _context.Customers;
            return View(customers);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            var customerId = customer.Id;

            return RedirectToAction("details", new { id = customerId });
        }

        [Route("Customers/{id:int}")]
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Find(id);
            return View(customer);
        }

        [Route("/customers/{id:int}/edit")]
        public IActionResult Edit(int id)
        {
            var c = _context.Customers.Find(id);

            return View(c);
        }

        [HttpPost]
        [Route("/customers/{id:int}")]
        public IActionResult Update(int id, Customer customer)
        {
            customer.Id = id;
            _context.Customers.Update(customer);
            _context.SaveChanges();

            return Redirect($"/customers/{customer.Id}");
        }

        public IActionResult Delete(int id)
        {
            var c = _context.Customers.Find(id);
            _context.Customers.Remove(c);
            _context.SaveChanges();

            return Redirect("/customers");
        }
    }
}
