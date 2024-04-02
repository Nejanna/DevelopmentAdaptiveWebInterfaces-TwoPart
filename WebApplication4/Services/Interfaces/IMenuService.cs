using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IMenuService
    {
        Task<IEnumerable<MenuItem>> GetMenuItems();
        Task<MenuItem> GetMenuItem(int id);
        Task<int> CreateMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(MenuItem menuItem);
        Task DeleteMenuItem(int id);
    }
}
