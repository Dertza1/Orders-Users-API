using System.ComponentModel.DataAnnotations;
namespace ShoppingCenter.Database
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Number { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }

        public List<OrderComposition> Compositions { get; set; }
        public Client Client { get; set; }
        public User User { get; set; }
    }
}
