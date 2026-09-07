using DairyFlow.Business.Interfaces;
using DairyFlow.Business.Providers;
using DairyFlow.Data.Repository;

namespace DairyFlow.Helpers
{
    public class DependencyInjectionHelper
    {

        public static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped(typeof(DatabaseContext));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUsersProvider), typeof(UserProvider));
            services.AddScoped(typeof(ICategoriesProvider), typeof(CategoriesProvider));
            services.AddScoped(typeof(IBrandsProvider), typeof(BrandsProvider));
            services.AddScoped(typeof(IProductsProvider), typeof(ProductsProvider));
            services.AddScoped(typeof(IInventoriesProvider), typeof(InventoriesProvider));
            services.AddScoped(typeof(IStockTransactionProvider), typeof(StockTransactionProvider));
        }

    }
}
