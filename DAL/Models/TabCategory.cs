namespace PetShopFinal.DAL.Models
{
    public class TabCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TabText> TabTexts { get; set; }
    }
}
