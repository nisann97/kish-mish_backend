using System;
using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
	public interface IValuesRepository
	{

        Task<List<CompanyValue>> GetAll();
        Task<CompanyValue> GetById(int id);
        Task Create(CompanyValue value);
        Task Delete(CompanyValue value);
        Task Edit(int id, CompanyValue value);
    }
}

