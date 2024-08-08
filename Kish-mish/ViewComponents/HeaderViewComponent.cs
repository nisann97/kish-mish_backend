using System;
using Domain.Entities;
using Kish_mish.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Kish_mish.ViewComponents
{
	public class HeaderViewComponent : ViewComponent
    {
		 
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _accessor;
        //private readonly IBasketService _basketService;
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(ISettingService settingService,
                                    IHttpContextAccessor accessor,
                                   //IBasketService basketService,
                                   UserManager<AppUser> userManager)
        {
            _settingService = settingService;
            //_basketService = basketService;
            _userManager = userManager;
            _accessor = accessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = new();
            if (User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            }

            var setting = await _settingService.GetAll();

            Dictionary<string, string> values = new();

            foreach (KeyValuePair<int, Dictionary<string, string>> item in setting)
            {
                values.Add(item.Value["Key"], item.Value["Value"]);
            }


            HeaderVM response = new()
            {
                Settings = values,
                UserFullName = user.FullName
            };

         






            //ViewBag.BasketCount = await _basketService.GetBasketProductCount(user.Id);


            return await Task.FromResult(View(response));
        }
    }
}

