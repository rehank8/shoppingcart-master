using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShoppinCartApp.Helper;
using ShoppingCartApp.Models.Models;
using ShoppingCartApp.Models.Utility;
using ShoppingCartApp.Repositories.Repos;
using ShoppingCartApp.Repositories.Repos.CartItemRepos;
using ShoppingCartApp.Repositories.Repos.CategoryRepos;
using ShoppingCartApp.Repositories.Repos.ProductsRepos;
using ShoppingCartApp.Repositories.Repos.Role;
using ShoppingCartApp.Repositories.Repos.SubCategoryRepos;
using ShoppingCartApp.Repositories.Repos.UserRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppinCartApp.ServiceExtensions
{
    public static class ApplicationServiceCollectionExtensions
    {

        public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var securitykey = configuration.GetSection("JwtHelper");
            services.Configure<JwtHelper>(securitykey);
            var appsettings = securitykey.Get<JwtHelper>();
            var key = Encoding.ASCII.GetBytes(appsettings.SecretKey);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                });
            return services;
        }
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCognitoIdentity();
            services.AddScoped<DbContext, ShoppingCartDBContext>();
            services.AddDbContext<ShoppingCartDBContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(ShoppingCartDBContext))));
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<ICartItemsRepo, CartItemsRepo>();
            services.AddScoped<IProductsRepo, ProductsRepo>();
            services.AddScoped<ISecurityAnswersRepo, SecurityAnswersRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ISubCategoryRepo, SubCategoryRepo>();
            //services.AddSingleton<IAmazonCognitoIdentityProvider>(cognitoIdentityProvider);
            //services.AddSingleton<CognitoUserPool>(cognitoUserPool);
            return services;
        }
    }
}
