using Domain.Common;

namespace Repository.Repositories.Interfaces
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);


    }
}

