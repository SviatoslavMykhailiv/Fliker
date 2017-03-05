using System.Data.Entity;
using Data.Dto;

namespace Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
    }
}
