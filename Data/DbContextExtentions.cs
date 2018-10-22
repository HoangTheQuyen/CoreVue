using System.Collections.Generic;
using System.Linq;
using ECommerce.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }
        public static void EnsureSeeded(this EcommerceContext context)
        {
            if (UserManager.FindByEmailAsync("stu@ratcliffe.io").
                            GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Stu",
                    LastName = "Ratcliffe",
                    UserName = "stu@ratcliffe.io",
                    Email = "stu@ratcliffe.io",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
            }
            AddProducts(context);
        }

        private static void AddProducts(EcommerceContext context)
        {
            if (context.Products.Any() == false)
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Name = "Samsung Galaxy S8",
                        Slug = "samsung-galaxy-s8",
                        Thumbnail = "http://placehold.it/200x300",
                        ShortDescription = "Samsung Galaxy S8 Android smartphone with true edge to edge display",
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.",
                        Price = 499.99M
                    },
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}