using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repositories.Contexts;

public class TokenizeDbContext : DbContext
{
    public TokenizeDbContext(DbContextOptions<TokenizeDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}