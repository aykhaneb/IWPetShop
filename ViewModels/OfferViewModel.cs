using PetShopFinal.DAL.Models;

namespace PetShopFinal.ViewModels
{
    public class OfferViewModel
    {
        public List<OfferMain>? OfferMain { get; set; }
        public List<Connected>? Connected { get; set; }
        public List<PlanOffer>? PlanOffer { get; set; }
        public List<TabOffer>? TabOffer { get; set; }

    }
}
