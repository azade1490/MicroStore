namespace MicroStore.OrderService.DTO;
public class OrderDto
{
    public Guid ID { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

}
