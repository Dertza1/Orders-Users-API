namespace ShoppingCenter.Models
{
    public class OrderCompositionsPutDto
    {
        public decimal Price { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }
    }
}
