using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopFinal.DAL.Models
{
    public class Featured
    {
        public int Id { get; set; }
        public string Head { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }

    }
}
