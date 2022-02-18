using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> GetWithSpecificationAsync(ISpecification<T> specification);
    Task<IReadOnlyList<T>> ListSpecifiedAsync(ISpecification<T> specification);
    Task<int> CountAsync(ISpecification<T> spec);
}