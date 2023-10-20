using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShopFinal.DAL.Models;
using System.Security.Cryptography.X509Certificates;

namespace PetShopFinal.DAL
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Puffles> Puffles { get; set; }
        public DbSet<Featured> Featured { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<Hurry> Hurry { get; set; }
        public DbSet<TeamLG> TeamLG { get; set; }
        public DbSet<Treats> Treats { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<OrganicLG> OrganicLG { get; set; }
        public DbSet<TabCategory> TabCategories { get; set; }
        public DbSet<TabText> TabText { get; set; }
        public DbSet<TeamAbout> TeamAbout { get; set; }
        public DbSet<OrganicAbout> OrganicAbout { get; set; }
        public DbSet<Numbers> Numbers { get; set; }
        public DbSet<OfferMain> OfferMains { get; set; }
        public DbSet<Connected> Connecteds { get; set; }
        public DbSet<PlanOffer> PlanOffers { get; set; }
        public DbSet<TabOffer> TabOffers { get; set; }
        public DbSet<FirstTest> FirstTests { get; set; }
        public DbSet<ThirdUsers> ThirdUserss { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HeaderBottom> HeaderBottoms { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<FooterTop> FooterTops { get; set; }
        public DbSet<HeaderSM> HeaderSMs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PopularProduct> PopularProducts { get; set; }
        public DbSet<PopProducts> PopProductss { get; set; }
        public DbSet<MainProducts> MainProductss { get; set; }
        public DbSet<Touch> Touchs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<LForm> LForms { get; set; }
        public DbSet<Types> Typess { get; set; }
        public DbSet<TypeImage> TypeImages { get; set; }

    }
}
