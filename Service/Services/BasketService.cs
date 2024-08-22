﻿using System;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using static Service.Services.BasketService;

namespace Service.Services
{

    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task Create(Basket basket)
        {
            await _basketRepository.Create(basket);
        }

        public async Task DecreaseExistProductCount(string name, string userId)
        {
            await _basketRepository.DecreaseExistProductCount(name, userId);
        }

        public async Task<bool> ExistProduct(string name, string userId)
        {
            return await _basketRepository.ExistProduct(name, userId);
        }

        public async Task<List<Basket>> GetAll()
        {
            return await _basketRepository.GetAll();
        }

        public async Task<List<Basket>> GetBasketByUser(string id)
        {
            return await _basketRepository.GetBasketByUser(id);
        }

        public async Task<Basket> GetBasketProductById(int id)
        {
            return await _basketRepository.GetBasketProductById(id);
        }

        public async Task<int> GetBasketProductCount(string id)
        {
            return await _basketRepository.GetBasketProductCount(id);
        }

        public async Task IncreaseExistProductCount(string name, string userId, int count = 1)
        {
            await _basketRepository.IncreaseExistProductCount(name, userId, count);
        }

        public async Task Remove(Basket basket)
        {
            await _basketRepository.Remove(basket);
        }
    }
}