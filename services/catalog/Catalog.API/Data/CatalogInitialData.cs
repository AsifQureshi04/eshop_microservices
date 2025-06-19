using JasperFx.CodeGeneration.Frames;
using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellationToken)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetConfiguredProducts());
            await session.SaveChangesAsync();   
        }

        private static IEnumerable<Product> GetConfiguredProducts() => new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple iPhone 14",
                Category = new List<string> { "Electronics", "Smartphones" },
                Description = "Latest iPhone with A15 Bionic chip and improved camera system.",
                ImageFile = "iphone14.jpg",
                Price = 799.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung Galaxy S23",
                Category = new List<string> { "Electronics", "Smartphones" },
                Description = "Flagship Android smartphone with Snapdragon 8 Gen 2 processor.",
                ImageFile = "galaxy_s23.jpg",
                Price = 899.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Dell XPS 15",
                Category = new List<string> { "Electronics", "Laptops" },
                Description = "High-performance laptop with Intel i7 and 16GB RAM.",
                ImageFile = "dell_xps_15.jpg",
                Price = 1299.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sony WH-1000XM5",
                Category = new List<string> { "Electronics", "Headphones" },
                Description = "Noise-canceling wireless headphones with immersive sound quality.",
                ImageFile = "sony_wh1000xm5.jpg",
                Price = 399.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple MacBook Air M2",
                Category = new List<string> { "Electronics", "Laptops" },
                Description = "Ultra-lightweight laptop with Apple M2 chip and Retina display.",
                ImageFile = "macbook_air_m2.jpg",
                Price = 1199.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Google Pixel 7",
                Category = new List<string> { "Electronics", "Smartphones" },
                Description = "Google's flagship phone with Tensor G2 chip and Android 13.",
                ImageFile = "pixel7.jpg",
                Price = 599.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Bose QuietComfort Earbuds",
                Category = new List<string> { "Electronics", "Earbuds" },
                Description = "Premium noise-canceling earbuds with deep bass and clear sound.",
                ImageFile = "bose_qc_earbuds.jpg",
                Price = 279.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "LG OLED C2 55” TV",
                Category = new List<string> { "Electronics", "Televisions" },
                Description = "Stunning 4K OLED TV with AI-powered processing for crisp visuals.",
                ImageFile = "lg_oled_c2.jpg",
                Price = 1499.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Amazon Echo Dot (5th Gen)",
                Category = new List<string> { "Electronics", "Smart Home" },
                Description = "Smart speaker with Alexa and improved bass for great sound.",
                ImageFile = "echo_dot_5th_gen.jpg",
                Price = 49.99m
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Fitbit Charge 5",
                Category = new List<string> { "Electronics", "Wearables" },
                Description = "Advanced fitness tracker with heart rate monitoring and GPS.",
                ImageFile = "fitbit_charge_5.jpg",
                Price = 129.99m
            }
        };

    }
}
