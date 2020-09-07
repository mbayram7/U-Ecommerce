using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    //serialize ya da serialization, bir datayı kolayca ulaşılabilir hala getirmek ya da bir datayı platform bağımsız hale getirmektir(json,xml,binary).
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);

                    }

                    await context.SaveChangesAsync();

                }



                if (!context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    //serialize ya da serialization, bir datayı kolayca ulaşılabilir hala getirmek ya da bir datayı platform bağımsız hale getirmektir(json,xml,binary).
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);

                    }

                    await context.SaveChangesAsync();

                }


                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    //serialize ya da serialization, bir datayı kolayca ulaşılabilir hala getirmek ya da bir datayı platform bağımsız hale getirmektir(json,xml,binary).
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);

                    }

                    await context.SaveChangesAsync();

                }

            }

            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

        }
    }
}
