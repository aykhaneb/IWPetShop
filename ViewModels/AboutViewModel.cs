using PetShopFinal.DAL.Models;
namespace PetShopFinal.ViewModels
{
    public class AboutViewModel
    {
        public List<TabCategory>? TabCategory { get; set; }
        public List<TabText>? TabText { get; set; }
        public List<TeamAbout>? TeamAbout { get; set; }
        public List<OrganicAbout>? OrganicAbout { get; set; }
        public List<Numbers>? Numbers { get; set; }

    }
}
