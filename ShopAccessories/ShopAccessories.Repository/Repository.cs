﻿using Microsoft.EntityFrameworkCore;

namespace ShopAccessories.Repository;


public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AplicationContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(AplicationContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByKeysAsync(params object[] keys)
    {
        return await _dbSet.FindAsync(keys);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}