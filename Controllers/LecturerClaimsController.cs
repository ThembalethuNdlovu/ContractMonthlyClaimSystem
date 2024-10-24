﻿using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Data;
using ContractMonthlyClaimSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Create(LecturerClaim claim, IFormFile UploadedFile)
        {
            if (ModelState.IsValid)
            {
                if (UploadedFile != null && UploadedFile.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await UploadedFile.CopyToAsync(memoryStream);
                        claim.UploadedFileContent = memoryStream.ToArray();
                        claim.UploadedFileName = UploadedFile.FileName;
                    }
                }
                _context.Add(claim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claim);
        }
        // GET: LecturerClaims/Review
        public async Task<IActionResult> Review()
        {
            var pendingClaims = await _context.LecturerClaims
                .Where(c => c.Status == ClaimStatus.Pending)
                .ToListAsync();
            return View(pendingClaims);
        }

        // POST: LecturerClaims/Approve
        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var claim = await _context.LecturerClaims.FindAsync(id);
            if (claim != null)
            {
                claim.Status = ClaimStatus.Approved;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Review));
        }

        // POST: LecturerClaims/Reject
        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var claim = await _context.LecturerClaims.FindAsync(id);
            if (claim != null)
            {
                claim.Status = ClaimStatus.Rejected;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Review));
        }

    }
}
