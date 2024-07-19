namespace YourProject.Infrastructure.DTOs;
public class DiscountDTO
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int CompanyId { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime? UseDate { get; set; } // Nullable if it might not be set immediately
    public double DiscountAmount { get; set; }
    public int Quantity { get; set; }
    public int QuantityUsed { get; set; }
}