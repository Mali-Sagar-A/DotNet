using WEB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB_API.DAL;

public class CustumerDbContext : DbContext
{
    public CustumerDbContext()
    {

    }
    public CustumerDbContext(DbContextOptions<CustumerDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var ServerVersion = new MySqlServerVersion(new Version(8, 0, 29));

        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost; Port=3306; Database = Exam; User Id = root; Password=Prasad@0102", ServerVersion);
        }

    }

}
