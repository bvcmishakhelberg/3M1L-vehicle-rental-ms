using _3M1L_vehicle_rental_ms.Data;
using _3M1L_vehicle_rental_ms.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class CustomerController : Controller
    {
        private readonly RentalDbContext _context;

        public CustomerController(RentalDbContext context)
        {
            _context = context;
        }

        // GET: /Customer
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        // GET: /Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        [HttpPost]
        public async Task<IActionResult> Create(Customer model)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Customer/Edit/{id}
        public IActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // POST: /Customer/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(Customer model)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Customer/Delete/{id}
        public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        // POST: /Customer/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}