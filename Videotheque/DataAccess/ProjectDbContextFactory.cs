using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Videotheque.DataAccess
{
    public class BooksDbContextFactory : IDesignTimeDbContextFactory<BooksDbContext>
    {
        public BooksDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BooksDbContext>();
            optionsBuilder.UseSqlite("Data Source=database.db");

            return new BooksDbContext(optionsBuilder.Options);
        }
    }
}
