using System;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
	public interface IBlogRepository
	{
        Task<List<Blog>> GetAll();
        Task<Blog> GetById(int id);
        Task Create(Blog about);
        Task Delete(Blog about);
        Task Edit(int id, Blog about);
    }
}

