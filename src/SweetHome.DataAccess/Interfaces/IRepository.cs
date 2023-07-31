namespace SweetHome.DataAccess.Interfaces;

public interface IRepository<TEntity, TViewModel>
{
    public Task<int> CreateAsync(TEntity entity);

    public Task<int> UpdateAsync(long id, TEntity entity);

    public Task<int> DeliteAsync(long id);

    public Task<TViewModel> GetByIdAsync(long id);

    public Task<long> CountAsync();

}
