
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using static System.Environment;


namespace Videotheque.DataAccess
{
    public class BooksDbContext : DbContext
    {
        private static BooksDbContext _context = null;
        public static async Task<BooksDbContext> GetCurrent()
        {
            if (_context == null)
            {
                _context = new BooksDbContext(
                    Path.Combine(GetFolderPath(SpecialFolder.LocalApplicationData), "mix.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }

        internal BooksDbContext(DbContextOptions options) : base(options) { }
        private BooksDbContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }

        public string DatabasePath { get; }

        public DbSet<Model.Film> Films { get; set; }
        public DbSet<Model.Genre> Genres { get; set; }
        public DbSet<Model.Media> Medias { get; set; }
        public DbSet<Model.Media_Genre> MediasGenres { get; set; }
        public DbSet<Model.Serie> Series { get; set; }
        public DbSet<Model.Ami> Amis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Media_Genre>()
                                .HasKey(ab => new { ab.Id_Media, ab.Id_Genre });

                                              
        }
    }
}
