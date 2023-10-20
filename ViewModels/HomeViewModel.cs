using PetShopFinal.DAL.Models;

namespace PetShopFinal.ViewModels
{
    public class HomeViewModel
    {
        public List<Puffles>? Puffles { get; set; }
        public List<Featured>? Featured { get; set; }
        public List<Offer>? Offer { get; set; }
        public List<Hurry>? Hurry { get; set; }
        public List<TeamLG>? TeamLG { get; set; }
        public List<Treats>? Treats { get; set; }
        public List<News>? News { get; set; }
        public List<OrganicLG>? OrganicLG { get; set; }
    }
}
