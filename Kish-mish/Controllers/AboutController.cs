using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kish_mish.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kish_mish.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IValuesService _valuesService;


        public AboutController(IAboutService aboutService,
                                IValuesService valuesService)
        {
            _aboutService = aboutService;
            _valuesService = valuesService;
        }



        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
            var about = await _aboutService.GetAll();
            var values = await _valuesService.GetAll();


            AboutVM model = new()
            {
                About = about,
                Values = values


            };

            return View(model);
        }
    }
}

