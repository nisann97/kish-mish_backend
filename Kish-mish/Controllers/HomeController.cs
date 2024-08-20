using System.Diagnostics;
using Kish_mish.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Kish_mish.Controllers;

public class HomeController : Controller
{
    private readonly ISliderService _sliderService;
    private readonly ICategoryService _categoryService;
    private readonly IProductService _productService;

    public HomeController(ISliderService sliderService,
                         ICategoryService categoryService,
                         IProductService productService)
    {
        _sliderService = sliderService;
        _categoryService = categoryService;
        _productService = productService;

    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAll();
        var products = await _productService.GetAll();
        var sliders = await _sliderService.GetAll();
        //var features = await _featureService.GetAll();
        //var ads = await _adService.GetAll();
        //var banners = await _bannerService.GetAll();
        //var vegetables = await _productService.GetVegetables();
        //var bestSellers = await _productService.GetBestSellerProducts();
        //var comments = await _commentService.GetAll();
        //var statistics = await _statisticService.GetAll();

        HomeVM model = new()
        {
            Categories = categories,
            Products = products,
            Sliders = sliders,
            //SliderInfo = sliderInfos.FirstOrDefault(),
            //Features = features,
            //Ads = ads,
            //Vegetables = vegetables,
            //Banner = banners.FirstOrDefault(),
            //BestSellers = bestSellers,
            //Comments = comments,
            //Statistics = statistics,
        };

        return View(model);
    }
}

