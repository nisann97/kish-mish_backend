using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class ValuesRepository : IValuesRepository
	{
        private readonly AppDbContext _context;
        public ValuesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(CompanyValue value)
        {
            await _context.Values.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CompanyValue value)
        {
            _context.Values.Remove(value);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id,  CompanyValue value)
        {
            var existValue = await GetById(id);
            existValue.Title = value.Title;
            existValue.Image = value.Image;
            existValue.Description = value.Description;
            await _context.SaveChangesAsync();
        }

      
        public async Task<List<CompanyValue>> GetAll()
        {
            return await _context.Values.ToListAsync();
        }

        public async Task<CompanyValue> GetById(int id)
        {
            return await _context.Values.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
	
