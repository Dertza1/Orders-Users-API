using System.ComponentModel.DataAnnotations;
namespace ShoppingCenter.Database
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Fio { get; set; }

    }
}
