using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class BlogRepository : IBlogRepository
	{
        private readonly AppDbContext _context;
        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Blog blog)
        {
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(int id, Blog blog)
        {
            var existBlog = await GetById(id);
            existBlog.Description = blog.Description;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Blog>> GetAll()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}