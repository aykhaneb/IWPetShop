using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopFinal.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string PruductName { get; set; }
        public int Price { get; set; }
    }
}
