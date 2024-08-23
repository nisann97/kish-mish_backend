using System;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Services.Interfaces
{
	public interface IAccountService
	{

        Task<List<AppUser>> GetAll();
        Task<IList<string>> GetRoles(AppUser user);


    }
}


