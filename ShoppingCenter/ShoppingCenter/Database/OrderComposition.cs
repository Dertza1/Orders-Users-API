using System.ComponentModel.DataAnnotations;

namespace ShoppingCenter.Database
{
    public class OrderComposition
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodsId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
     
        public Order Order { get; set; }
        public Goods Goods { get; set; }
    }
}
