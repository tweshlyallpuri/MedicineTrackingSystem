using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicineTracker.Models;
using MedicineTracker.Data.Database;
using Microsoft.EntityFrameworkCore;
using MedicineTracker.Data.Models;

namespace MedicineTracker.Controllers
{
    public class MedicineController : Controller
    {
        private readonly ILogger<MedicineController> _logger;
        private MedicineDbContext _context;

        public MedicineController(ILogger<MedicineController> logger, MedicineDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Medicines.ToListAsync());
        }

        // GET: Medicine/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.FullName.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (medicine == null)
            {
                return NotFound();
            }

            return View(medicine);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,BrandName,Price,Quantity,ExpiryDate,Notes")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
