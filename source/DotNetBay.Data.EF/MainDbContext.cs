using System.Data.Entity;

namespace DotNetBay.Data.EF
{
    public class MainDbContext : DbContext
    {
        public MainDbContext() : base("DatabaseConnection")
        {
            
        }
         
    }
}