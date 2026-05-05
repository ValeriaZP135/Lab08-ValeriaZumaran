using Lab08_ValeriaZumaran.Interfaces;
using Lab08_ValeriaZumaran.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab08_ValeriaZumaran.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly Lab8DbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(Lab8DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression) =>
        await _dbSet.Where(expression).ToListAsync();

    public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression) =>
        await _dbSet.FirstOrDefaultAsync(expression);

    public async Task<IEnumerable<TResult>> SelectAsync<TResult>(
        Expression<Func<T, TResult>> selector) =>
        await _dbSet.Select(selector).ToListAsync();

    public async Task<IEnumerable<TResult>> SelectWhereAsync<TResult>(
        Expression<Func<T, bool>> condition,
        Expression<Func<T, TResult>> selector) =>
        await _dbSet.Where(condition).Select(selector).ToListAsync();
}