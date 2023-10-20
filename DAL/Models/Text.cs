namespace PetShopFinal.DAL.Models
{
    public class Text
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TabCategory Category { get; set; }
        public int CategoryId { get; set; }
    }
}
