namespace ShoppingCenter.Models
{
    public class OrderPutDto
    {
        public int Number { get; set; }
        public int ClientId { get; set; }

        public List<OrderCompositionsPutDto> Positions { get; set; }

    }
}
