using System;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.About;
using Kish_mish.Areas.Admin.ViewModels.Blog;
using Kish_mish.Areas.Admin.ViewModels.Slider;
using Kish_mish.Areas.Admin.ViewModels.Values;
using Kish_mish.Helpers.Enums;
using Kish_mish.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Service.Services.Interfaces;

namespace Kish_mish.Areas.Admin.Controllers
{


    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BlogController(IBlogService blogService,
                                IWebHostEnvironment env,
                                AppDbContext context)
        {
            _blogService = blogService;
            _env = env;
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var datas = await _blogService.GetAll();

            List<BlogVM> model = datas.Select(m => new BlogVM { Id = m.Id, Title = m.Title }).ToList();
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
        public async Task<IActionResult> Create(BlogCreateVM request)
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




            Blog blog = new()
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName

            };

            await _blogService.Create(blog);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var existBlog = await _blogService.GetById((int)id);

            if (existBlog is null) return NotFound();

            BlogDetailVM response = new() { Title = existBlog.Title, Description = existBlog.Description, Image = existBlog.Image };
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest("Id cannot be null.");

            var blog = await _blogService.GetById(id.Value);

            if (blog == null)
                return NotFound("Blog is not found.");

            BlogEditVM model = new()
            {
                Title = blog.Title,
                Description = blog.Description,
                Image = blog.Image
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BlogEditVM request)
        {
            if (id == null)
                return BadRequest("Id cannot be null.");



            var blog = await _blogService.GetById(id.Value);

            if (blog == null)
                return NotFound("Blog is not found.");

            if (request.NewImage == null)
            {

                return RedirectToAction(nameof(Index));
            }

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "Invalid image format.");
                request.Image = blog.Image;
                return View(request);
            }

            if (!request.NewImage.CheckFileSize(3))
            {
                ModelState.AddModelError("NewImage", "File size must be less than 3 MB.");
                request.Image = blog.Image;
                return View(request);
            }


            string oldPath = Path.Combine(_env.WebRootPath, "assets", "images", blog.Image);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }


            string newFileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
            string newPath = Path.Combine(_env.WebRootPath, "assets", "images", newFileName);
            await request.NewImage.SaveFileToLocalAsync(newPath);

            blog.Image = newFileName;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var existBlog = await _blogService.GetById((int)id);

            if (existBlog is null) return NotFound();

            string existImage = Path.Combine(_env.WebRootPath, "images", existBlog.Image);

            existImage.DeleteFileFromLocal();

            await _blogService.Delete(existBlog);
            return RedirectToAction(nameof(Index));

        }
    }

}

