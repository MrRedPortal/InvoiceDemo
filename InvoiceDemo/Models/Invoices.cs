using System.ComponentModel.DataAnnotations;

namespace InvoiceDemo;

public class Invoices
{
    [Key]
    public int InvoiceId { get; set; }

    [Required]
    public string Contact { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public bool Draft { get; set; }
}