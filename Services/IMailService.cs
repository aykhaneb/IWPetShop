using PetShopFinal.Data;

namespace PetShopFinal.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(RequestEmail requestEmail);
    }
}
