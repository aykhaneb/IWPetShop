using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopFinal.DAL.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
