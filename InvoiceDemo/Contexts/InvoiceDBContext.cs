using Microsoft.EntityFrameworkCore;

namespace InvoiceDemo;

public class InvoiceDBContext : DbContext
{
    public InvoiceDBContext(DbContextOptions<InvoiceDBContext> options) : base(options)
    {
    }
    
    public DbSet<Invoices> Invoices { get; set; }
}
