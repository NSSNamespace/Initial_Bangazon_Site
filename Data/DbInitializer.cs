using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bangazon.Models;

/*
Author: Elliott Williams
*/

namespace Bangazon.Data
{
    //The DbInitializer class is used to seed the database (BangazonContext)
    public static class DbInitializer
    {
        //Method: The initialize method creates a scoped variable "context," which represents a session with the database. If there are any products currently in the database, then it will not be seeded.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonContext>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return;
                }

                var customers = new Customer[]
                {
                  new Customer {
                      FirstName = "Carson",
                      LastName = "Alexander",
                      StreetAddress = "100 Infinity Way"
                  },
                  new Customer {
                      FirstName = "Steve",
                      LastName = "Brownlee",
                      StreetAddress = "92 Main Street"
                  },
                  new Customer {
                      FirstName = "Tractor",
                      LastName = "Ryan",
                      StreetAddress = "1666 Catalina Blvd"
                  }
                };

                foreach (Customer c in customers)
                {
                    context.Customer.Add(c);
                }
                context.SaveChanges();

                var productTypes = new ProductType[]
                {
                  new ProductType {
                      Label = "Electronics"
                  },
                  new ProductType {
                      Label = "Appliances"
                  },
                  new ProductType {
                      Label = "Housewares"
                  },
                };

                foreach (ProductType i in productTypes)
                {
                    context.ProductType.Add(i);
                }
                context.SaveChanges();


                var products = new Product[]
                {
                  new Product {
                      Description = "Colorful throw pillows to liven up your home",
                      ProductTypeId = productTypes.Single(s => s.Label == "Housewares").ProductTypeId,
                      Title = "Throw Pillow",
                      Price = 7.49M,
                      CustomerId = customers.Single(s => s.FirstName == "Tractor").CustomerId
                  },
                  new Product {
                      Description = "A 2012 iPod Shuffle. Headphones are included. 16G capacity.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "iPod Shuffle",
                      Price = 18.00M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                  new Product {
                      Description = "Stainless steel refrigerator. Three years old. Minor scratches.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Appliances").ProductTypeId,
                      Title = "Samsung refrigerator",
                      Price = 500.00M,
                      CustomerId = customers.Single(s => s.FirstName == "Carson").CustomerId
                  },
                    new Product {
                      Description = "New 13-inch Macbook Pro, mid 2012 model.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Macbook Pro",
                      Price = 1099.00M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Bose® - SoundTrue® Around-Ear Headphones II (iOS) - Charcoal Black.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Bose Headphones",
                      Price = 129.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Mechanical gaming keyboard, all keys individually backlit and customizable.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Logitech G910 keyboard",
                      Price = 139.00M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Optical gaming mouse, customizeble weight and lighting.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Logitech G502 mouse",
                      Price = 89.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "14-inch full HD IPS display, aluminum body chromebook.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Acer Chromebook 14",
                      Price = 299.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "HP Pavilion 21.5-Inch IPS LED HDMI VGA Monitor.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "HP Flatscreen monitor",
                      Price = 99.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Cooler Master HAF 932 Advanced Full Tower Case with SuperSpeed USB 3.0",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Cooler Master computer tower",
                      Price = 160.00M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "eagate Expansion 1TB Portable External Hard Drive USB 3.0",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Seagate external hard drive",
                      Price = 54.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Anker PowerLine Micro USB (3ft) - Durable Charging Cable.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Anker charging cable",
                      Price = 4.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                  new Product {
                      Description = "Anker 40W 4-Port USB Wall Charger PowerPort 4, Multi-Port USB Charger with Foldable Plug",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Anker wall charger",
                      Price = 25.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Tractor").CustomerId
                  },
                  new Product {
                      Description = "Hoover Linx BH50010 Cordless Stick Vacuum Cleaner",
                      ProductTypeId = productTypes.Single(s => s.Label == "Housewares").ProductTypeId,
                      Title = "Hoover vacuum",
                      Price = 95.30M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                  new Product {
                      Description = "KRUPS EA8808 2-IN-1 Touch Cappuccino Fully Automatic Espresso Machine, 57-Ounce, Black",
                      ProductTypeId = productTypes.Single(s => s.Label == "Appliances").ProductTypeId,
                      Title = "Cappuccino and espresso machine",
                      Price = 1299.00M,
                      CustomerId = customers.Single(s => s.FirstName == "Carson").CustomerId
                  },
                    new Product {
                      Description = "Ultrasonic Cool Mist Humidifier - Premium Humidifying Unit with Whisper-quiet Operation, Automatic Shut-off, and Night Light Function.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Ultrasonic humidifier",
                      Price = 49.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Apple Watch Sport, Space Grey Aluminum Case/Black Band, 42mm.",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Apple smartwatch",
                      Price = 199.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Cambridge SoundWorks OontZ Angle 3 Next Generation Ultra Portable Wireless Bluetooth Speaker",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Bluetooth speaker",
                      Price = 27.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Anker PowerCore 20100 - Ultra High Capacity Power Bank",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Anker power bank",
                      Price = 39.99M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Belkin 6-Outlet Power Strip Surge Protector with 2-Foot Power Cord, 200 Joules (2-Pack)",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Belkin power strip",
                      Price = 9.37M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "SanDisk Cruzer CZ36 64GB USB 2.0 Flash Drive",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "SanDisk flash drive",
                      Price = 19.45M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "EVGA GeForce GTX 750 Ti FTW GDDR5 Graphics Card",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "EVGA graphics card",
                      Price = 132.37M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Intel Core i5 6600K 3.90 GHz Quad Core Skylake Desktop Processor",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Intel Processor",
                      Price = 237.39M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "Corsair Vengeance Pro 16GB (2x8GB) DDR3 2400MHz PC3 19200 Desktop RAM, Red",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Desktop RAM",
                      Price = 96.41M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  },
                    new Product {
                      Description = "ASUS Z170-A ATX DDR4 Motherboard",
                      ProductTypeId = productTypes.Single(s => s.Label == "Electronics").ProductTypeId,
                      Title = "Asus motherboard",
                      Price = 149.98M,
                      CustomerId = customers.Single(s => s.FirstName == "Steve").CustomerId
                  }
                };

                foreach (Product i in products)
                {
                    context.Product.Add(i);
                }
                context.SaveChanges();
            }
        }
    }
}