using Microsoft.EntityFrameworkCore;
namespace CountryApi.Modals
{
    public class CountryContext:DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options):base(options)
        {
        }
            
            
            public DbSet<CountryItem> CountryItems { get; set; } = null!;
    }
    
}