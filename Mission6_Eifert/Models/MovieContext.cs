using Microsoft.EntityFrameworkCore;
namespace Mission6_Eifert.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options) //Constructor
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}