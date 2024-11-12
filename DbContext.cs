using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public ComicSystemContext(DbContextOptions<ComicSystemContext> options) : base(options){}

    public DbSet<ComicBook> ComicBooks {get;set;}
    public DbSet<Customer> Customers {get;set;}
    public DbSet<Rental> Rentals {get;set;}
    public DbSet<RentalDetail> RentalDetails {get;set;}
}