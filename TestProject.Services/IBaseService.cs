using System.Threading.Tasks;

namespace TestProject.Services
{
    public interface IBaseService<T>
    {
        Task<T> GetAsync(long id);

        Task<T> CreateAsync(T entity);

        Task<bool> UpdateAsync(T entity);

        Task<bool> DeleteAsync(long id);
    }
}
