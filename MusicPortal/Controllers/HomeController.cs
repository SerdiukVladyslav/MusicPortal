using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Filters;
using MusicPortal.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPortal.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        private readonly MusicPortalContext _context;

        public HomeController(MusicPortalContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortBy, int page = 1)
        {
            HttpContext.Session.SetString("path", Request.Path);
            int pageSize = 9;
            ViewBag.SortBy = sortBy;

            IQueryable<Song> songs = _context.Songs
                .Include(s => s.Genre)
                .Include(s => s.Artists)
                .Include(s => s.Albums)
                .Include(s => s.Countries);

            // Применяем сортировку
            switch (sortBy)
            {
                case "songTitle":
                    songs = songs.OrderBy(s => s.Title);
                    break;
                case "albumTitle":
                    songs = songs.OrderBy(s => s.Albums.Album);
                    break;
                case "albumYear":
                    songs = songs.OrderBy(s => s.Albums.Year);
                    break;
                case "artistName":
                    songs = songs.OrderBy(s => s.Artists.Artist);
                    break;
                case "genreName":
                    songs = songs.OrderBy(s => s.Genre.Name);
                    break;
                case "countryName":
                    songs = songs.OrderBy(s => s.Countries.Country);
                    break;
                default:
                    break;
            }

            var count = await songs.CountAsync();
            var items = await songs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);

            return View(viewModel);
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangeCulture(string lang)
        {
            string? returnUrl = HttpContext.Session.GetString("path") ?? "/Home/Index";

            // Список культур
            List<string> cultures = new List<string>() { "uk", "ru", "en", "lt" };
            if (!cultures.Contains(lang))
            {
                lang = "uk";
            }

            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(10); // срок хранения куки - 10 дней
            Response.Cookies.Append("lang", lang, option); // создание куки
            return Redirect(returnUrl);
        }
    }
}
