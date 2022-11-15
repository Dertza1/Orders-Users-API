namespace ShoppingCenter.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Number { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        public List<OrderCompositionsDto> Positions { get; set; }
    }
}
