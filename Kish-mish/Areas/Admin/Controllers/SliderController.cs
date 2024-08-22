using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Slider;
using Kish_mish.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(ISliderService sliderService,
                                IWebHostEnvironment env,
                                AppDbContext context)
        {
            _sliderService = sliderService;
            _env = env;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _sliderService.GetAll();

            List<SliderVM> model = datas.Select(m => new SliderVM { Id = m.Id, SliderImage = m.Image }).ToList();
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
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.SliderImage.CheckFileType("image/"))
            {

                ModelState.AddModelError("SliderImage", "Only image format is accepted");
                return View();
            }

            if (!request.SliderImage.CheckFileSize(3))
            {
                ModelState.AddModelError("SliderImage", "File size must be less than 3 Mb");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.SliderImage.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets", "images", fileName);

            await request.SliderImage.SaveFileToLocalAsync(path);

            await _sliderService.Create(new Slider { Image = fileName });
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var existSlider = await _sliderService.GetById((int)id);

            if (existSlider is null) return NotFound();

            SliderDetailVM response = new() { SliderImage = existSlider.Image };
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest("Id cannot be null.");

            var slider = await _sliderService.GetById(id.Value);

            if (slider == null)
                return NotFound("Slider not found.");

            return View(new SliderEditVM { Image = slider.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, SliderEditVM request)
        {
            if (id == null)
                return BadRequest("Id cannot be null.");

          

            var slider = await _sliderService.GetById(id.Value);

            if (slider == null)
                return NotFound("Slider not found.");

            if (request.NewImage == null)
            {

                return RedirectToAction(nameof(Index));
            }

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "Invalid image format.");
                request.Image = slider.Image;
                return View(request);
            }

            if (!request.NewImage.CheckFileSize(3))
            {
                ModelState.AddModelError("NewImage", "File size must be less than 3 MB.");
                request.Image = slider.Image;
                return View(request);
            }


            string oldPath = Path.Combine(_env.WebRootPath, "assets", "images", slider.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }


            string newFileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "assets", "images", newFileName);
            await request.NewImage.SaveFileToLocalAsync(newPath);

            slider.Image = newFileName;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var existSlider = await _sliderService.GetById((int)id);

            if (existSlider is null) return NotFound();

            string existImage = Path.Combine(_env.WebRootPath, "images", existSlider.Image);

            existImage.DeleteFileFromLocal();

            await _sliderService.Delete(existSlider);
            return RedirectToAction(nameof(Index));

        }
    }
}
