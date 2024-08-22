using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Category;
using Kish_mish.Helpers.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();

            List<CategoryVM> model = categories.Select(m => new CategoryVM { Id = m.Id, CategoryName = m.Name }).ToList();

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
        public async Task<IActionResult> Create(CategoryCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExist = await _categoryService.CategoryIsExist(request.CategoryName);

            if (isExist)
            {
                ModelState.AddModelError("CategoryName", "This category has already exist");
                return View();
            }

            await _categoryService.Create(new Category { Name = request.CategoryName });

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetById((int)id);

            if (category is null) return NotFound();

            await _categoryService.Delete(category);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            var category = await _categoryService.GetById((int)id);

            if (category is null) return NotFound();

            CategoryEditVM model = new() { CategoryName = category.Name };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, CategoryEditVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id is null) return BadRequest();

            var category = await _categoryService.GetById((int)id);

            if (category is null) return NotFound();

            await _categoryService.Edit((int)id, new Category { Name = request.CategoryName });

            return RedirectToAction(nameof(Index));
        }


    }
}
