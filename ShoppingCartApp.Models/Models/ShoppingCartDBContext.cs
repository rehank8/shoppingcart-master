using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.Models
{
    public class ShoppingCartDBContext : DbContext
    {
        public ShoppingCartDBContext(DbContextOptions<ShoppingCartDBContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SecurityQuestions> SecurityQuestions { get; set; }
        public DbSet<SecurityAnswers> SecurityAnswers { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategory { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductSubCategoryTypes> ProductSubCategoryTypes { get; set; }
        public DbSet<Brands> Brands { get; set; }
        //public DbSet<NewOrder> NewOrders { get; set; }
    }
}
