using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Product;
using Kish_mish.Areas.Admin.ViewModels.Slider;
using Kish_mish.Areas.Admin.ViewModels.Values;
using Kish_mish.Helpers.Enums;
using Kish_mish.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Service.Services;
using Service.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Areas.Admin.Controllers
{
   
        [Area("Admin")]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public class ValuesController : Controller
        {
            private readonly IValuesService _valuesService;
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _env;
            public ValuesController(IValuesService valuesService,
                                    IWebHostEnvironment env,
                                    AppDbContext context)
            {
                _valuesService = valuesService;
                _env = env;
                _context = context;

            }
            [HttpGet]
            public async Task<IActionResult> Index()
            {
                var datas = await _valuesService.GetAll();

                List<ValuesVM> model = datas.Select(m => new ValuesVM { Id = m.Id, Title = m.Title }).ToList();
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
        public async Task<IActionResult> Create(ValuesCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {

                ModelState.AddModelError("Image", "Only image format is accepted");
                return View();
            }

            if (!request.Image.CheckFileSize(3))
            {
                ModelState.AddModelError("Image", "File size must be less than 3 Mb");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = Path.Combine(_env.WebRootPath, "assets", "images", fileName);

            await request.Image.SaveFileToLocalAsync(path);




            CompanyValue value = new()
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName

            };

            await _valuesService.Create(value);
            return RedirectToAction(nameof(Index));
        }
        
    


            [HttpGet]
            public async Task<IActionResult> Detail(int? id)
            {
                if (id is null) return BadRequest();

                var existValue = await _valuesService.GetById((int)id);

                if (existValue is null) return NotFound();

                ValuesDetailVM response = new() { Title = existValue.Title, Description = existValue.Description, Image = existValue.Image };
                return View(response);
            }

            [HttpGet]
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                    return BadRequest("Id cannot be null.");

                var value = await _valuesService.GetById(id.Value);

                if (value == null)
                    return NotFound("Values not found.");

            ValuesEditVM model = new()
            {
                Title = value.Title,
                Description = value.Description,
                Image = value.Image
            };
                return View(model);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int? id, SliderEditVM request)
            {
                if (id == null)
                    return BadRequest("Id cannot be null.");



                var value = await _valuesService.GetById(id.Value);

                if (value == null)
                    return NotFound("Value not found.");

                if (request.NewImage == null)
                {

                    return RedirectToAction(nameof(Index));
                }

                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "Invalid image format.");
                    request.Image = value.Image;
                    return View(request);
                }

                if (!request.NewImage.CheckFileSize(3))
                {
                    ModelState.AddModelError("NewImage", "File size must be less than 3 MB.");
                    request.Image = value.Image;
                    return View(request);
                }


                string oldPath = Path.Combine(_env.WebRootPath, "assets", "images", value.Image);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }


                string newFileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                string newPath = Path.Combine(_env.WebRootPath, "assets", "images", newFileName);
                await request.NewImage.SaveFileToLocalAsync(newPath);

                value.Image = newFileName;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            [Authorize(Roles = "SuperAdmin")]
            public async Task<IActionResult> Delete(int? id)
            {
                if (id is null) return BadRequest();

                var existValue = await _valuesService.GetById((int)id);

                if (existValue is null) return NotFound();

                string existImage = Path.Combine(_env.WebRootPath, "images", existValue.Image);

                existImage.DeleteFileFromLocal();

                await _valuesService.Delete(existValue);
                return RedirectToAction(nameof(Index));

            }
        }
    
}

