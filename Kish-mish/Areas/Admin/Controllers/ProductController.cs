﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Product;
using Kish_mish.Helpers.Enums;
using Kish_mish.Helpers.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin, Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _env;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,
                                 IWebHostEnvironment env,
                                 ICategoryService categoryService)
        {
            _productService = productService;
            _env = env;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            List<ProductVM> model = products.Select(m => new ProductVM { Id = m.Id, ProductName = m.Name }).ToList();


            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAll();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM request)
        {
            var categories = await _categoryService.GetAll();
            ViewBag.categories = new SelectList(categories, "Id", "Name");

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}

            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", "File type must be image");
                    return View();
                }

                if (!item.CheckFileSize(2))
                {
                    ModelState.AddModelError("Images", "Image size must be less than 2");
                    return View();
                }
            }

            List<ProductImageVM> images = new();

            foreach (var item in request.Images)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                string path = Path.Combine(_env.WebRootPath, "assets", "images", fileName);

                await item.SaveFileToLocalAsync(path);

                images.Add(new ProductImageVM
                {
                    Image = fileName,
                });
            }

            images.FirstOrDefault().IsMain = true;

            Product product = new()
            {
                Name = request.Name,
                Description = request.Description,
                Price = decimal.Parse(request.Price),
                CategoryId = request.CategoryId,
                Count = request.ProductCount,
                ProductImages = images.Select(m => new ProductImage { Image = m.Image, IsMain = m.IsMain }).ToList(),
            };

            await _productService.Create(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var product = await _productService.GetById((int)id);

            if (product is null) return NotFound();

            ProductDetailVM model = new()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category.Name,
                ProductImages = product.ProductImages.Select(m => new ProductImageVM { Image = m.Image, IsMain = m.IsMain }).ToList(),
                Count = product.Count,
              
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var categories = await _categoryService.GetAll();
            ViewBag.categories = new SelectList(categories, "Id", "Name");

            if (id is null) return BadRequest();
            var product = await _productService.GetById((int)id);
            if (product is null) return NotFound();

            ProductEditVM model = new()
            {
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.Price.ToString(),
                ProductCount = product.Count,
                ExistProductImages = product.ProductImages.Select(m => new ProductEditImageVM { Id = m.Id, Name = m.Image, IsMain = m.IsMain, ProductId = m.ProductId }).ToList(),
                CategoryId = product.CategoryId,
               
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int? id, int? productId)
        {
            if (id is null) return BadRequest();

            Product product = await _productService.GetById((int)productId);

            if (product is null) return NotFound();


            var existImage = product.ProductImages.FirstOrDefault(m => m.Id == id);

            if (existImage.IsMain)
            {
                return Problem();
            }

            string path = Path.Combine(_env.WebRootPath, "img", existImage.Image);
            path.DeleteFileFromLocal();

            await _productService.DeleteImage(existImage);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeMainImage(int? id, int? productId)
        {
            if (id is null || productId is null) return BadRequest();

            Product product = await _productService.GetById((int)productId);

            if (product is null) NotFound();

            await _productService.ChangeMainImage(product, (int)id);

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, ProductEditVM request)
        {
            var categories = await _categoryService.GetAll();
            ViewBag.categories = new SelectList(categories, "Id", "Name");
            
            if (id is null) return BadRequest();

            var existProduct = await _productService.GetById((int)id);

            if (existProduct is null) return NotFound();

            List<ProductImage> images = existProduct.ProductImages.ToList();

            if (request.NewProductImages is not null)
            {
                foreach (var item in request.NewProductImages)
                {
                    if (!item.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("NewProductImages", "File type must be image");
                        request.ExistProductImages = existProduct.ProductImages.Select(m => new ProductEditImageVM { Id = m.Id, Name = m.Image, IsMain = m.IsMain, ProductId = m.ProductId }).ToList();
                        return View(request);
                    }

                    if (!item.CheckFileSize(2))
                    {
                        ModelState.AddModelError("NewProductImages", "Image size must be less than 2");
                        request.ExistProductImages = existProduct.ProductImages.Select(m => new ProductEditImageVM { Id = m.Id, Name = m.Image, IsMain = m.IsMain, ProductId = m.ProductId }).ToList();
                        return View(request);
                    }
                }

                foreach (var item in request.NewProductImages)
                {
                    string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                    string path = Path.Combine(_env.WebRootPath, "assets", "images", fileName);

                    await item.SaveFileToLocalAsync(path);

                    images.Add(new ProductImage
                    {
                        Image = fileName
                    });
                }
            }

         
            Product product = new()
            {
                Name = request.ProductName,
                Description = request.ProductDescription,
                Price = decimal.Parse(request.ProductPrice),
                CategoryId = request.CategoryId,
                Count = request.ProductCount,
                ProductImages = images,
            };

            await _productService.Edit((int)id, product);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            Product existProduct = await _productService.GetById((int)id);
            if (existProduct is null) return NotFound();

            foreach (var item in existProduct.ProductImages)
            {
                var path = Path.Combine(_env.WebRootPath, "assets", "images", item.Image);
                path.DeleteFileFromLocal();
            }

            await _productService.Delete(existProduct);
            return RedirectToAction(nameof(Index));
        }
    }
}

