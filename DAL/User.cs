using Microsoft.AspNetCore.Identity;

namespace PetShopFinal.DAL
{
    public class User : IdentityUser
    {
        public string? Fullname { get; set; } 
    }
}
