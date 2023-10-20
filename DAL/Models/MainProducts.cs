using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopFinal.DAL.Models
{
    public class MainProducts
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Name { get; set; }
        public int ProductPrice { get; set; }
    }
}
