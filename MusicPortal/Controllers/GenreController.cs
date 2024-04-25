using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Filters;
using MusicPortal.Models;

namespace MusicPortal.Controllers
{
    [Culture]
    public class GenreController : Controller
    {
        private readonly MusicPortalContext _context;

        public GenreController(MusicPortalContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("path", Request.Path);
            var genres = _context.Genres.ToList();
            return View(genres);
        }

        public IActionResult Create()
        {
            HttpContext.Session.SetString("path", Request.Path);
            return View(new Genre());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Genre genreName)
        {
            _context.Add(genreName);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Genre");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            HttpContext.Session.SetString("path", Request.Path);
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Genre genreName)
        {
            if (id != genreName.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(genreName);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(genreName.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Genre");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            HttpContext.Session.SetString("path", Request.Path);
            if (id == null)
            {
                return NotFound();
            }

            var artist = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre != null)
            {
                _context.Genres.Remove(genre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Genre");
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
