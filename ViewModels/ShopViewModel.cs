using PetShopFinal.DAL.Models;

namespace PetShopFinal.ViewModels
{
    public class ShopViewModel
    {
        public List<Product>? Product { get; set; }
        public List<PopularProduct>? PopularProduct { get; set; }
        public List<PopProducts>? PopProducts { get; set; }
        public List<MainProducts>? MainProducts { get; set; }
    }
}
