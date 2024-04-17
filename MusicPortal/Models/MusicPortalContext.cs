using Microsoft.EntityFrameworkCore;

namespace MusicPortal.Models
{
    public class MusicPortalContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<Countries> Countries { get; set; }

        public MusicPortalContext(DbContextOptions<MusicPortalContext> options) : base(options)
        {
            if (Database.EnsureCreated())
            {
                Albums slipknotAlbum = new Albums { Album = "Slipknot", AlbumCover = "/Images/Slipknot Self-Titled.jpg", Year = 1999 };
                Albums grayChapterAlbum = new Albums { Album = ".5: The Gray Chapter", AlbumCover = "/Images/The Gray Chapter.jpeg", Year = 2014 };
                Albums subliminalVersesAlbum = new Albums { Album = "Vol. 3: The Subliminal Verses", AlbumCover = "/Images/Vol 3 The Subliminal Verses.jpg", Year = 2004 };
                Albums theEndSoFarAlbum = new Albums { Album = "The End, So Far", AlbumCover = "/Images/The End, So Far.jpg", Year = 2022 };
                Albums mutterAlbum = new Albums { Album = "Mutter", AlbumCover = "/Images/Mutter.jpg", Year = 2001 };
                Albums herzeleidAlbum = new Albums { Album = "Herzeleid", AlbumCover = "/Images/Herzeleid.jpg", Year = 1995 };
                Albums rammsteinAlbum = new Albums { Album = "Rammstein", AlbumCover = "/Images/Rammstein Self-Titled.png", Year = 2019 };
                Genre metalGenre = new Genre { Name = "Метал" };
                Artists slipknotArtist = new Artists { Artist = "Slipknot" };
                Artists rammsteinArtist = new Artists { Artist = "Rammstein" };
                Countries usaCountry = new Countries { Country = "США" };
                Countries germanCountry = new Countries { Country = "Німеччина" };

                Albums?.Add(slipknotAlbum);
                Albums?.Add(grayChapterAlbum);
                Albums?.Add(subliminalVersesAlbum);
                Albums?.Add(theEndSoFarAlbum);
                Albums?.Add(mutterAlbum);
                Albums?.Add(herzeleidAlbum);
                Albums?.Add(rammsteinAlbum);
                Genres?.Add(metalGenre);
                Artists?.Add(slipknotArtist);
                Artists?.Add(rammsteinArtist);
                Countries?.Add(usaCountry);
                Countries?.Add(germanCountry);

                Songs?.Add(new Song { Title = "(sic)", Albums = slipknotAlbum, Genre = metalGenre, Artists = slipknotArtist, Countries = usaCountry, MusicFile = "/Songs/(sic).mp3" });
                Songs?.Add(new Song { Title = "Eyeless", Albums = slipknotAlbum, Genre = metalGenre, Artists = slipknotArtist, Countries = usaCountry, MusicFile = "/Songs/Eyeless.mp3" });
                Songs?.Add(new Song { Title = "Wait and Bleed", Albums = slipknotAlbum, Genre = metalGenre, Artists = slipknotArtist, Countries = usaCountry, MusicFile = "/Songs/Wait and Bleed.mp3" });
                Songs?.Add(new Song { Title = "The Devil in I", Albums = grayChapterAlbum, Genre = metalGenre, Artists = slipknotArtist, Countries = usaCountry, MusicFile = "/Songs/The Devil in I.mp3" });
                Songs?.Add(new Song { Title = "Duality", Albums = subliminalVersesAlbum, Genre = metalGenre, Artists = slipknotArtist, Countries = usaCountry, MusicFile = "/Songs/Duality.mp3" });
                Songs?.Add(new Song { Title = "The Dying Song (Time To Sing)", Albums = theEndSoFarAlbum, Genre = metalGenre, Artists = slipknotArtist, Countries = usaCountry, MusicFile = "/Songs/The Dying Song (Time To Sing).mp3" });
                Songs?.Add(new Song { Title = "Sonne", Albums = mutterAlbum, Genre = metalGenre, Artists = rammsteinArtist, Countries = germanCountry, MusicFile = "/Songs/Sonne.mp3" });
                Songs?.Add(new Song { Title = "Du riechst so gut", Albums = herzeleidAlbum, Genre = metalGenre, Artists = rammsteinArtist, Countries = germanCountry, MusicFile = "/Songs/Du riechst so gut.mp3" });
                Songs?.Add(new Song { Title = "Deutschland", Albums = rammsteinAlbum, Genre = metalGenre, Artists = rammsteinArtist, Countries = germanCountry, MusicFile = "/Songs/Deutschland.mp3" });
                SaveChanges();
            }
        }
    }
}
