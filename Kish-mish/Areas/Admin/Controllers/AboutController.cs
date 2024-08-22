using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.About;
using Kish_mish.Helpers.Enums;
using Kish_mish.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _env;
        public AboutController(IAboutService aboutService,
                                       IWebHostEnvironment env)
        {
            _aboutService = aboutService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var datas = await _aboutService.GetAll();

            List<AboutVM> model = datas.Select(m => new AboutVM { Id = m.Id, Description = m.Description }).ToList();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _aboutService.Create(new About { Description = request.Description});
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();
            var existAd = await _aboutService.GetById((int)id);
            if (existAd is null) return NotFound();

            AboutEditVM model = new() { Description = existAd.Description};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AboutEditVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id is null) return BadRequest();
            var existAd = await _aboutService.GetById((int)id);
            if (existAd is null) return NotFound();


                await _aboutService.Edit((int)id, new About {Description = request.Description});

            
           

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var existAd = await _aboutService.GetById((int)id);
            if (existAd is null) return NotFound();

            await _aboutService.Delete(existAd);

            return RedirectToAction(nameof(Index));
        }
    }

}