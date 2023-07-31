using SweetHome.DataAccess.Utils;
using SweetHome.DataAccess.ViewModels;
using SweetHome.Service.Dtos.Users;

namespace SweetHome.Service.Interfaces.Users;

public interface IUserService
{
    public Task<bool> CreateAsync(UserCreateDto dto);

    public Task<IList<UsersViewModel>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long userId);

    public Task<long> CountAsync();

    public Task<UsersViewModel> GetByIdAsync(long id);
}
