namespace PetShopFinal.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Text> Texts { get; set; }
    }
}
