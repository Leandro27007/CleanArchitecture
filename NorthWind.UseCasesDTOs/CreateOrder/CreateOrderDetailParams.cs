namespace NorthWind.UseCasesDTOs.CreateOrder
{
    public class CreateOrderDetailParams
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
