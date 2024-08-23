using System;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BlogService : IBlogService
	{

        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task Create(Blog blog)
        {
            await _blogRepository.Create(blog);
        }

        public async Task Delete(Blog blog)
        {
            await _blogRepository.Delete(blog);
        }

        public async Task Edit(int id, Blog blog)
        {
            await _blogRepository.Edit(id, blog);
        }

        public async Task<List<Blog>> GetAll()
        {
            return await _blogRepository.GetAll();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _blogRepository.GetById(id);
        }
    }
}

