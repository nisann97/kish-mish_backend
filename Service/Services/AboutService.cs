using System;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using static Service.Services.AboutService;

namespace Service.Services
{

    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }
        public async Task Create(About about)
        {
            await _aboutRepository.Create(about);
        }

        public async Task Delete(About about)
        {
            await _aboutRepository.Delete(about);
        }

        public async Task Edit(int id, About about)
        {
            await _aboutRepository.Edit(id, about);
        }

        public async Task<List<About>> GetAll()
        {
            return await _aboutRepository.GetAll();
        }

        public async Task<About> GetById(int id)
        {
            return await _aboutRepository.GetById(id);
        }
    }
}
