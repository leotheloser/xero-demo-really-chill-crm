using Microsoft.EntityFrameworkCore;

namespace ReallyChillCRMApi.Models
{
    public class ReallyChillCRMContext : DbContext
    {
        public ReallyChillCRMContext(DbContextOptions<ReallyChillCRMContext> options)
            : base(options)
        {
        }
        public DbSet<RCContact> RCContacts { get; set; }
    }
}
