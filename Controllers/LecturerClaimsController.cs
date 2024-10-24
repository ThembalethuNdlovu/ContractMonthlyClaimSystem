using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Data;
using ContractMonthlyClaimSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LecturerClaimsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturerClaimsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LecturerClaims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LecturerClaims/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LecturerClaim claim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claim);
        }

        // GET: LecturerClaims
        public async Task<IActionResult> Index()
        {
            return View(await _context.LecturerClaims.ToListAsync());
        }
    }
}
