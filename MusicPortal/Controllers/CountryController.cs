using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Filters;
using MusicPortal.Models;

namespace MusicPortal.Controllers
{
    [Culture]
    public class CountryController : Controller
    {
        private readonly MusicPortalContext _context;

        public CountryController(MusicPortalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("path", Request.Path);
            var countries = _context.Countries.ToList();
            return View(countries);
        }

        public IActionResult Create()
        {
            HttpContext.Session.SetString("path", Request.Path);
            return View(new Countries());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country")] Countries countryName)
        {
            _context.Add(countryName);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Country");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            HttpContext.Session.SetString("path", Request.Path);
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country")] Countries countryName)
        {
            if (id != countryName.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(countryName);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(countryName.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Country");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            HttpContext.Session.SetString("path", Request.Path);
            if (id == null)
            {
                return NotFound();
            }

            var country = await _context.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country != null)
            {
                _context.Countries.Remove(country);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Country");
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
