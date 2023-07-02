using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NerdShop.WebApp.Models
{
    [Table("ShoppingCartItems")]
    public class ShoppingCartItem
    {

        public int ShoppingCartItemId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
