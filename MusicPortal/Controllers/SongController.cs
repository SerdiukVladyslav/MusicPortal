using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicPortal.Filters;

namespace MusicPortal.Controllers
{
    [Culture]
    public class SongController : Controller
    {
        private readonly MusicPortalContext _context;
        IWebHostEnvironment _appEnvironment;

        public SongController(MusicPortalContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Song
        public IActionResult Index()
        {
            var songs = _context.Songs
                .Include(s => s.Genre)
                .Include(s => s.Artists)
                .Include(s => s.Albums)
                .Include(s => s.Countries)
                .ToList();

            return View(songs);
        }

        // GET: Song/Create
        public IActionResult Create()
        {
            HttpContext.Session.SetString("path", Request.Path);
            var song = new Song();
            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Name");
            ViewBag.ArtistsId = new SelectList(_context.Artists, "Id", "Artist");
            ViewBag.AlbumsId = new SelectList(_context.Albums, "Id", "Album");
            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Country");
            return View(song);
        }

        // POST: Song/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongId,Title,GenreId,ArtistsId,AlbumsId,CountryId,MusicFile")] Song song, IFormFile musicFile)
        {
            if (musicFile != null)
            {
                string musicPath = "/Songs/" + musicFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + musicPath, FileMode.Create))
                {
                    await musicFile.CopyToAsync(fileStream);
                }

                song.MusicFile = musicPath;
            }

            var genre = await _context.Genres.FindAsync(song.GenreId);
            var artists = await _context.Artists.FindAsync(song.ArtistsId);
            var albums = await _context.Albums.FindAsync(song.AlbumsId);
            var country = await _context.Countries.FindAsync(song.CountryId);

            song.Genre = genre;
            song.Artists = artists;
            song.Albums = albums;
            song.Countries = country;

            _context.Add(song);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        // GET: Song/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            HttpContext.Session.SetString("path", Request.Path);
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            ViewBag.GenreId = new SelectList(_context.Genres, "Id", "Name");
            ViewBag.ArtistsId = new SelectList(_context.Artists, "Id", "Artist");
            ViewBag.AlbumsId = new SelectList(_context.Albums, "Id", "Album");
            ViewBag.CountryId = new SelectList(_context.Countries, "Id", "Country");

            return View(song);
        }

        // POST: Song/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongId,Title,GenreId,ArtistsId,AlbumsId,CountryId,MusicFile")] Song song, IFormFile musicFile)
        {
            if (id != song.SongId)
            {
                return NotFound();
            }

            try
            {
                if (musicFile != null)
                {
                    string musicPath = "/Songs/" + musicFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + musicPath, FileMode.Create))
                    {
                        await musicFile.CopyToAsync(fileStream);
                    }

                    song.MusicFile = musicPath;
                }

                var genre = await _context.Genres.FindAsync(song.GenreId);
                var artists = await _context.Artists.FindAsync(song.ArtistsId);
                var albums = await _context.Albums.FindAsync(song.AlbumsId);
                var country = await _context.Countries.FindAsync(song.CountryId);

                song.Genre = genre;
                song.Artists = artists;
                song.Albums = albums;
                song.Countries = country;

                _context.Update(song);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(song.SongId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Song/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            HttpContext.Session.SetString("path", Request.Path);
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Genre)
                .Include(s => s.Artists)
                .Include(s => s.Albums)
                .Include(s => s.Countries)
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Song/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                _context.Songs.Remove(song);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }
    }
}
