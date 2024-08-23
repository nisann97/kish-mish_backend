using System;
using Domain.Entities;

namespace Service.Services.Interfaces
{
	public interface IBlogService
	{
        Task<List<Blog>> GetAll();
        Task<Blog> GetById(int id);
        Task Create(Blog blog);
        Task Edit(int id, Blog blog);
        Task Delete(Blog blog);
    }
}

