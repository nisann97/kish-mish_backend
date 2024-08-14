using System;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
	public interface ISliderRepository
	{
        Task<List<Slider>> GetAll();
        Task<Slider> GetById(int id);
        Task Create(Slider slider);
        Task Delete(Slider slider);
        Task Edit(int id, Slider slider);
    }
}

