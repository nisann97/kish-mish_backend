using System;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class ValuesService : IValuesService
	{
        private readonly IValuesRepository _valuesRepository;
        public ValuesService(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }
        public async Task Create(CompanyValue value)
        {
            await _valuesRepository.Create(value);
        }

        public async Task Delete(CompanyValue value)
        {
            await _valuesRepository.Delete(value);
        }

        public async Task Edit(int id, CompanyValue value)
        {
            await _valuesRepository.Edit(id, value);
        }

        public async Task<List<CompanyValue>> GetAll()
        {
            return await _valuesRepository.GetAll();
        }

        public async Task<CompanyValue> GetById(int id)
        {
            return await _valuesRepository.GetById(id);
        }
    }
}


