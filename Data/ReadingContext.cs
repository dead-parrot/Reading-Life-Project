using Microsoft.EntityFrameworkCore;
using ReadingLifeProject.Models;
using System.Data.Common;

namespace ReadingLifeProject.Data
{
    public class ReadingContext:DbContext
    {
        public ReadingContext(DbContextOptions<ReadingContext> opt): base(opt)
        {

        }

        public DbSet<Book> books { get; set; }
        }
}
