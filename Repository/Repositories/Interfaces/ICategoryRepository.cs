using System;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
	public interface ICategoryRepository
	{
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Create(Category category);
        Task Edit(int id, Category category);
        Task Delete(Category category);
        Task<bool> CategoryIsExist(string name);

    }
}

