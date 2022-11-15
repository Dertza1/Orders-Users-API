namespace ShoppingCenter.Models
{
    public class OrderCompositionsDto
    {
        public int GoodsId { get; set; }
        public string GoodsName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
