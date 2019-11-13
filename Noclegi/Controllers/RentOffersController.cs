using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Noclegi.Data;
using Noclegi.Helpers;
using Noclegi.Models;
using Noclegi.Models.RentOfferViewModels;

namespace Noclegi.Controllers
{
    public class RentOffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentOffersController(ApplicationDbContext context)
        {
            _context = context;
        }


  
        public async Task<IActionResult> Index()
        {
            return View(await _context.RentOffer.ToListAsync());


        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentOffer = await _context.RentOffer
                .SingleOrDefaultAsync(m => m.RentOfferId == id);
            if (rentOffer == null)
            {
                return NotFound();
            }

            return View(rentOffer);
        }

      
        [Authorize(Roles = "Administrator, User")]  
        public IActionResult Create()
        {
            var viewModel = new CreateRentOfferViewModel
            {
                Categories = _context.Category,
                Districts = _context.District
            };

            return View(viewModel);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentOfferId,Submitted,LastEdit,PostalCode,Title,Description,Price")] RentOffer rentOffer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rentOffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rentOffer);
        }




        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentOffer = await _context.RentOffer.SingleOrDefaultAsync(m => m.RentOfferId == id);
            if (rentOffer == null)
            {
                return NotFound();
            }
            return View(rentOffer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RentOfferId,Submitted,LastEdit,PostalCode,Title,Description,Price")] RentOffer rentOffer)
        {
            if (id != rentOffer.RentOfferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rentOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentOfferExists(rentOffer.RentOfferId))
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
            return View(rentOffer);
        }

 
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rentOffer = await _context.RentOffer
                .SingleOrDefaultAsync(m => m.RentOfferId == id);
            if (rentOffer == null)
            {
                return NotFound();
            }

            return View(rentOffer);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var rentOffer = await _context.RentOffer.SingleOrDefaultAsync(m => m.RentOfferId == id);
            _context.RentOffer.Remove(rentOffer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentOfferExists(string id)
        {
            return _context.RentOffer.Any(e => e.RentOfferId == id);
        }


    }
}
