using System;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
	public interface ISettingRepository
	{
        Task<Dictionary<int, Dictionary<string, string>>> GetAll();
        Task<Setting> GetById(int id);
        Task Create(Setting setting);
        Task Edit(int id, Setting setting);
        Task Delete(Setting setting);
    }
}

