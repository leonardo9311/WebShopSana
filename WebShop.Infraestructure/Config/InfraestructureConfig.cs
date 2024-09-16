using Microsoft.Extensions.DependencyInjection;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebShop.Core.Interfaces.Repository;
using WebShop.Core.Entity;
using WebShop.Infraestructure.Repository;
using WebShop.Core.Interfaces.Service;
using WebShop.Infraestructure.Service;
using WebShop.Infraestructure.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace WebShop.Infraestructure.Config
{
    public static class InfraestructureConfig
    {
        public static void AddInfraestructure(this IServiceCollection services,
                                              IConfiguration configuration)
        {
            
            #region Db
            services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("WebShopConnectionString"),
                    b=>b.MigrationsAssembly(typeof(ShopDbContext).Assembly.FullName)
                    )
            );
            #endregion Db

            #region Data
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IRepository<Order>, Repository<Order>>();
            services.AddTransient<IRepository<OrderDetail>, Repository<OrderDetail>>();
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<ProductCategory>, Repository<ProductCategory>>();
            #endregion Data

            #region Bussines
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
         
            #endregion Bussines
        }
    }
}
