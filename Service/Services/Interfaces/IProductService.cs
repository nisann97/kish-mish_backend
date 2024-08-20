﻿using System;
using Domain.Entities;
using Org.BouncyCastle.Bcpg;

namespace Service.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Create(Product category);
        Task Edit(int id, Product category);
        Task Delete(Product product);
        Task DeleteImage(ProductImage image);
        Task ChangeMainImage(Product product, int id);
        Task<List<Product>> GetAllPaginatedDatas(int page, int take = 9);
        Task<List<Product>> GetAllSearchedPaginatedDatas(int page, string searchText, int take = 9);
        Task<List<Product>> GetAllPriceFilteredPaginatedDatas(int page, int price, int take = 9);
        Task<List<Product>> GetCategoryFilteredPaginatedDatas(int page, int categoryId, int take = 9);
        Task<List<Product>> GetSortedPaginatedDatas(int page, string sortType, int take = 9);
        Task<int> GetPriceFilteredCount(int price);
        Task<int> GetSearchedCount(string searchText);
        Task<int> GetCategoryFilteredCount(int categoryId);
        Task<int> GetCount();
        int GetPageCount(int count, int take);
        //Task BuyProducts(List<Basket> basket);
    }


}

