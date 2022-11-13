using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Domain.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public string? CategoryName { get; set; }
    public bool IsWeighted { get; set; }
    public Status Status { get; set; }
}