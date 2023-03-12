
using CleanStore.Domain.Models.Common;
using System.Linq.Expressions;

namespace CleanStore.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T, ID> where T : BaseDomainModel where ID : struct
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        string includeString = null,
                                        bool disableTracking = true
        );

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                        List<Expression<Func<T, object>>> includes = null,
                                        bool disableTracking = true
        );

        Task<T> GetByIdAsync(ID id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(ID id, T entity);

        Task<T> DeleteAsync(T entity);
    }
}
