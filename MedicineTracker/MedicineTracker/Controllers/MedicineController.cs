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
        private IInMemoryMedicines _context;

        public MedicineController(ILogger<MedicineController> logger, IInMemoryMedicines context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(string SearchString)
        {
            var medicines = _context.Medicines;
            if (!string.IsNullOrEmpty(SearchString))
                medicines = medicines.Where(x => x.FullName.Contains(SearchString, StringComparison.OrdinalIgnoreCase)).ToList();
            return View(medicines);
        }

        // GET: Medicine/Details/5
        public IActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var medicine = _context.Medicines
                .FirstOrDefault(m => m.FullName.Equals(id, StringComparison.OrdinalIgnoreCase));
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
        public IActionResult Create([Bind("FullName,BrandName,Price,Quantity,ExpiryDate,Notes")] Medicine medicine)
        {
            if (ModelState.IsValid)
            {
                _context.Medicines.Add(medicine);
                return RedirectToAction(nameof(Index));
            }
            return View(medicine);
        }
        
        public IActionResult Error(int id)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorCode = id });
        }
    }
}
