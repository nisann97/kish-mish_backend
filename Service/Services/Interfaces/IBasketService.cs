using System;
using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface IBasketService
    {
        Task<List<Basket>> GetAll();
        Task Create(Basket basket);
        Task<List<Basket>> GetBasketByUser(string id);
        Task IncreaseExistProductCount(string name, string userId, int count = 1);
        Task DecreaseExistProductCount(string name, string userId);
        Task<bool> ExistProduct(string name, string userId);
        Task<int> GetBasketProductCount(string id);
        Task<Basket> GetBasketProductById(int id);
        Task Remove(Basket basket);
    }
}