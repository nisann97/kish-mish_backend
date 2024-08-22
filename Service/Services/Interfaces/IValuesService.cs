using System;
using Domain.Entities;

namespace Service.Services.Interfaces
{
	public interface IValuesService
	{
        Task<List<CompanyValue>> GetAll();
        Task<CompanyValue> GetById(int id);
        Task Create(CompanyValue value);
        Task Edit(int id, CompanyValue value);
        Task Delete(CompanyValue value);
    }
}

