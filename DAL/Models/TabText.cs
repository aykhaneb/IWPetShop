namespace PetShopFinal.DAL.Models
{
    public class TabText
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TabCategory TabCategory { get; set; }
        public int TabCategoryId { get; set; }
    }
}
