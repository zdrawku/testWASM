namespace DependentVariablesExample.Models.IGNW;

public class OrderDetailDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public double Discount { get; set; }
}
