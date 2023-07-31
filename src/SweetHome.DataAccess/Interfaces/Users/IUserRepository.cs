using SweetHome.DataAccess.Common.Interfaces;
using SweetHome.DataAccess.Repositories;
using SweetHome.DataAccess.ViewModels;
using SweetHome.Domain.Entities.Users;

namespace SweetHome.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User, UsersViewModel>,IGetAll<UsersViewModel>, ISearchable<UsersViewModel>
{
    public Task<User?> GetByPhoneAsync(string phone);
}
