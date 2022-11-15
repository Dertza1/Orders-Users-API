using System.ComponentModel.DataAnnotations;

namespace ShoppingCenter.Database
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Fio { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
