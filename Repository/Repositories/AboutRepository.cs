using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly AppDbContext _context;
        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(About about)
        {
            await _context.About.AddAsync(about);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(About about)
        {
            _context.About.Remove(about);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, About about)
        {
            var existAd = await GetById(id);
            existAd.Description = about.Description;
            await _context.SaveChangesAsync();
        }

        public async Task<List<About>> GetAll()
        {
            return await _context.About.ToListAsync();
        }

        public async Task<About> GetById(int id)
        {
            return await _context.About.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}