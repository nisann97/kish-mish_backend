﻿using System.Diagnostics;
using Domain.Entities;
using Kish_mish.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using Service.Services.Interfaces;

namespace Kish_mish.Controllers;

public class HomeController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly ICategoryService _categoryService;
    private readonly IHttpContextAccessor _accessor;
    private readonly IProductService _productService;
   
    private readonly IBasketService _basketService;
    private readonly IAboutService _aboutService;
    private readonly UserManager<AppUser> _userManager;
    public HomeController(UserManager<AppUser> userManager,
                         ISliderService sliderService,
                         ICategoryService categoryService,
                         IProductService productService,
                         IBasketService basketService,
                         IAboutService aboutService,
                         IHttpContextAccessor accessor)
    {
        _userManager = userManager;
        _sliderService = sliderService;
        _categoryService = categoryService;
        _productService = productService;
        _basketService = basketService;
        _aboutService = aboutService;
        _accessor = accessor;

    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAll();
        var products = await _productService.GetAll();
        var sliders = await _sliderService.GetAll();
        var about = await _aboutService.GetAll();
     
        HomeVM model = new()
        {
            Categories = categories,
            Products = products,
            Sliders = sliders,
            About = about
          
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToBasket(int? id)
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
            await _basketService.IncreaseExistProductCount(dbProduct.Name, user.Id);
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


        int count = await _basketService.GetBasketProductCount(user.Id);
        return Ok(new { count });
    }

}

