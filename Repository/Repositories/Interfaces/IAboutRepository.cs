using System;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
	public interface IAboutRepository
	{
        Task<List<About>> GetAll();
        Task<About> GetById(int id);
        Task Create(About about);
        Task Delete(About about);
        Task Edit(int id, About about);
    }
}

