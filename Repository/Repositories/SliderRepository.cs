using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
		    
        private readonly AppDbContext _context;
        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, Slider slider)
        {
            var existData = await GetById(id);
            existData.Image = slider.Image;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Slider>> GetAll()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<Slider> GetById(int id)
        {
            return await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);
        }
    }

}

