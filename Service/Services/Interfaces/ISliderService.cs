using System;
using Domain.Entities;

namespace Service.Services.Interfaces
{
	public interface ISliderService
	{
        Task<List<Slider>> GetAll();
        Task<Slider> GetById(int id);
        Task Create(Slider slider);
        Task Edit(int id, Slider slider);
        Task Delete(Slider slider);
    }
}

