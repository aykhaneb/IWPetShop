namespace PetShopFinal.DAL.Models
{
    public class TypeImage
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public Types Types { get; set; }
        public int TypeId { get; set; }
    }
}
