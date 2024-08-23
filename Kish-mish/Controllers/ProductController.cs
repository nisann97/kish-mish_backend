using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Product;
using Kish_mish.ViewModels.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBasketService _basketService;
        public ProductController(IProductService productService,
                                 ICategoryService categoryService,
                                 UserManager<AppUser> userManager,
                                 IBasketService basketService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _userManager = userManager;
            _basketService = basketService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            var existProduct = await _productService.GetById((int)id);

            if (existProduct is null) return NotFound();

            ProductDetailVM product = new()
            {
                Id = existProduct.Id,
                Name = existProduct.Name,
                Description = existProduct.Description,
                Price = existProduct.Price,
                Category = existProduct.Category.Name,
                ProductImages = existProduct.ProductImages.Select(m => new ProductImageVM { Image = m.Image, IsMain = m.IsMain }).ToList(),
            };

            List<Category> categories = await _categoryService.GetAll();
            List<Product> products = await _productService.GetAll();

            AppUser user = new();
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }



            ProductDetailPageVM model = new()
            {
                Product = product,
                Products = products,
                Categories = categories,
            };

            return View(model);
        }

      

        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int? id, int count)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return Problem();
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (id is null) return BadRequest();
            var dbProduct = await _productService.GetById((int)id);
            if (await _basketService.ExistProduct(dbProduct.Name, user.Id))
            {
                await _basketService.IncreaseExistProductCount(dbProduct.Name, user.Id, count);
                return Ok();
            }


            Basket basket = new()
            {
                ProductName = dbProduct.Name,
                ProductImage = dbProduct.ProductImages.FirstOrDefault(m => m.IsMain).Image,
                ProductCount = 1,
                ProductPrice = dbProduct.Price,
                UserId = user.Id,
            };
            await _basketService.Create(basket);

            List<Basket> products = await _basketService.GetBasketByUser(user.Id);


            int productCount = await _basketService.GetBasketProductCount(user.Id);
            return Ok(new { productCount });
        }
    }
}