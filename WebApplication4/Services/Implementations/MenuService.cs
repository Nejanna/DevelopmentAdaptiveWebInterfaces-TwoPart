using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly List<MenuItem> menuItems;

        public MenuService()
        {
            menuItems = new List<MenuItem>
        {
            new MenuItem { Id = 1, Name = "Miso Soup", Price = 4.99m, Description = "A savory broth made from fermented soybean paste, with tofu cubes, seaweed, and green onions.", Category = "Soups" },
            new MenuItem { Id = 2, Name = "Tom Yum Soup", Price = 5.99m, Description = "A tangy and spicy Thai soup with lemongrass, kaffir lime leaves, shrimp, mushrooms, and chili peppers.", Category = "Soups" },
            new MenuItem { Id = 3, Name = "California Roll", Price = 8.99m, Description = "A classic sushi roll filled with imitation crab meat, cucumber, and avocado, wrapped in sushi rice and seaweed.", Category = "Sushi" },
            new MenuItem { Id = 4, Name = "Dragon Roll", Price = 12.99m, Description = "An extravagant sushi roll featuring eel, avocado, cucumber, and crab meat, topped with thinly sliced avocado arranged to resemble a dragon's scales.", Category = "Sushi" },
            new MenuItem { Id = 5, Name = "Pho", Price = 10.49m, Description = "A Vietnamese noodle soup consisting of broth, rice noodles, herbs, and meat, typically beef or chicken, garnished with lime, bean sprouts, and chili peppers.", Category = "Soups" },
            new MenuItem { Id = 6, Name = "Sashimi Platter", Price = 18.99m, Description = "A selection of fresh raw fish and seafood thinly sliced and served with soy sauce, wasabi, and pickled ginger.", Category = "Sushi" },
            new MenuItem { Id = 7, Name = "Pad Thai", Price = 11.99m, Description = "A popular Thai stir-fried noodle dish made with rice noodles, eggs, tofu, shrimp, peanuts, bean sprouts, and a tangy tamarind sauce.", Category = "Noodles" },
            new MenuItem { Id = 8, Name = "Tonkotsu Ramen", Price = 13.99m, Description = "A rich and creamy Japanese noodle soup made with pork bone broth, wheat noodles, pork belly slices, soft-boiled egg, bamboo shoots, and green onions.", Category = "Noodles" },
            new MenuItem { Id = 9, Name = "Tempura Roll", Price = 9.99m, Description = "A crispy and light sushi roll filled with shrimp tempura, avocado, cucumber, and spicy mayo, wrapped in seaweed and sushi rice.", Category = "Sushi" },
            new MenuItem { Id = 10, Name = "Chicken Satay", Price = 7.99m, Description = "Grilled and marinated chicken skewers served with a peanut sauce and cucumber salad, a popular appetizer in Southeast Asian cuisine.", Category = "Appetizers" }

        };
        }
        public Task<IEnumerable<MenuItem>> GetMenuItems()
        {
            return Task.FromResult<IEnumerable<MenuItem>>(menuItems);
        }

        public Task<MenuItem> GetMenuItem(int id)
        {
            return Task.FromResult(menuItems.FirstOrDefault(item => item.Id == id));
        }

        public Task<int> CreateMenuItem(MenuItem menuItem)
        {
            menuItem.Id = menuItems.Count + 1;
            menuItems.Add(menuItem);
            return Task.FromResult(menuItem.Id);
        }

        public Task UpdateMenuItem(MenuItem menuItem)
        {
            var existingItem = menuItems.FirstOrDefault(item => item.Id == menuItem.Id);
            if (existingItem != null)
            {
                existingItem.Name = menuItem.Name;
                existingItem.Price = menuItem.Price;
                existingItem.Description = menuItem.Description;
                existingItem.Category = menuItem.Category;
            }
            else
            {
                throw new ArgumentException("Menu item not found.");
            }
            return Task.CompletedTask;
        }

        public Task DeleteMenuItem(int id)
        {
            var existingItem = menuItems.FirstOrDefault(item => item.Id == id);
            if (existingItem != null)
            {
                menuItems.Remove(existingItem);
            }
            else
            {
                throw new ArgumentException("Menu item not found.");
            }
            return Task.CompletedTask;
        }
    }

}
