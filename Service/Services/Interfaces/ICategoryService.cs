using System;
using Domain.Entities;

namespace Service.Services.Interfaces
{
	public interface ICategoryService
	{
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Delete(Category category);
        Task Edit(int id, Category category);
        Task Create(Category category);
        Task<bool> CategoryIsExist(string categoryName);

    }
}

