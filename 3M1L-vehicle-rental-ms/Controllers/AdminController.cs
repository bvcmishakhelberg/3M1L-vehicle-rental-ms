using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _3M1L_vehicle_rental_ms.Data;
using _3M1L_vehicle_rental_ms.Models;

namespace _3M1L_vehicle_rental_ms.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminDbContext _adminDbcontext;

        public AdminController(AdminDbContext adminDbcontext)
        {
            _adminDbcontext = adminDbcontext;
        }

        // GET: Admin
        [HttpGet]
        [Route("Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _adminDbcontext.Admins.ToListAsync());
        }

        // GET: Admin/Details/5
        [HttpGet]
        [Route("Admin/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _adminDbcontext.Admins
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // GET: Admin/Create
        [HttpGet]
        [Route("Admin/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [Route("Admin/Create")]
        public async Task<IActionResult> Create([Bind("AdminID,AdminName,AdminEmail,AdminPhoneNumber")] Admin admin)
        {
            if (ModelState.IsValid)
            {
                _adminDbcontext.Add(admin);
                await _adminDbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admin/Edit/5
        [HttpGet]
        [Route("Admin/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _adminDbcontext.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [Route("Admin/Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("AdminID,AdminName,AdminEmail,AdminPhoneNumber")] Admin admin)
        {
            if (id != admin.AdminID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _adminDbcontext.Update(admin);
                    await _adminDbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.AdminID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admin/Delete/5
        [HttpGet]
        [Route("Admin/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _adminDbcontext.Admins
                .FirstOrDefaultAsync(m => m.AdminID == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        private bool AdminExists(int id)
        {
            return _adminDbcontext.Admins.Any(e => e.AdminID == id);
        }
    }
}
