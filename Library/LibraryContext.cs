
using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Barrow> Barrows { get; set; }
    public DbSet<History> Histories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-8ROR24L\MSSQLSERVER20;Lib;integrated security=true;Trusted_Connection=True;");
    }
}
