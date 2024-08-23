using System;
using Domain.Entities;
using Kish_mish.Areas.Admin.ViewModels.Values;
using Kish_mish.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Kish_mish.Controllers
{
	public class BlogController : Controller
	{
        
            private readonly IBlogService _blogService;


            public BlogController(IBlogService blogService)
            {
                _blogService = blogService;
            }



            // GET: /<controller>/
            public async Task<IActionResult> Index()
            {
                var blogs = await _blogService.GetAll();

             
                return View(blogs);
            }
        
    }
}

