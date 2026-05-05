namespace Lab08_ValeriaZumaran.Interfaces;

using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
    Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression);
    Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector);
    Task<IEnumerable<TResult>> SelectWhereAsync<TResult>(
        Expression<Func<T, bool>> condition,
        Expression<Func<T, TResult>> selector);
}