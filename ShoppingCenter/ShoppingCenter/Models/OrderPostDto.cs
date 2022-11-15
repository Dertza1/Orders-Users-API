namespace ShoppingCenter.Models
{
    public class OrderPostDto
    {
        public int Number { get; set; }
        public int ClientId { get; set; }

        public List<OrderCompositionsPostDto> Positions { get; set; }

    }
}
