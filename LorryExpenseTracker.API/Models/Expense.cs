public class Expense
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public string Category { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; } = "";
    public string? ReceiptUrl { get; set; }
    public Vehicle Vehicle { get; set; }
}
