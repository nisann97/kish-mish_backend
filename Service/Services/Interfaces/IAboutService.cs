using System;
using Domain.Entities;

namespace Service.Services.Interfaces
{
	public interface IAboutService
	{
        Task<List<About>> GetAll();
        Task<About> GetById(int id);
        Task Create(About about);
        Task Edit(int id, About about);
        Task Delete(About about);
    }
}

