using SweetHome.DataAccess.Interfaces;
using SweetHome.DataAccess.Interfaces.Users;
using SweetHome.DataAccess.Repositories.Users;
using SweetHome.DataAccess.Utils;
using SweetHome.DataAccess.ViewModels;
using SweetHome.Domain.Entities.Users;
using SweetHome.Domain.Exceptions;
using SweetHome.Domain.Exceptions.Users;
using SweetHome.Service.Common.Helpers;
using SweetHome.Service.Dtos.Users;
using SweetHome.Service.Interfaces.Commons;
using SweetHome.Service.Interfaces.Users;

namespace SweetHome.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileServise;

    public UserService(IUserRepository userRepository,
        IFileService fileService)
    {
        this._repository = userRepository;
        this._fileServise = fileService;

    }

    public async Task<long> CountAsync() => await _repository.CountAsync();
    

    public async Task<bool> CreateAsync(UserCreateDto dto)
    {
        User user = new User()
        {
            Ism = dto.Ism,
            Familiya = dto.Familiya,
            TelNomer = dto.TelNomer,
            Parol = dto.Parol,
            UpdatedAt = TimeHelper.GetDateTime(),
            CreatedAt = TimeHelper.GetDateTime()
        };

        var result = await _repository.CreateAsync(user);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long userId)
    {
        var user = await _repository.GetByIdAsync(userId);
        if (user is null) throw new UserNotFountException();

        var dbResult = await _repository.DeliteAsync(userId);
        return dbResult > 0;
    }

    public async Task<IList<UsersViewModel>> GetAllAsync(PaginationParams @params)
    {
        var user = await _repository.GetAllAsync(@params);
        return user;
    }

    public async Task<UsersViewModel> GetByIdAsync(long id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user is null) throw new UserNotFountException();
        else return user;
    }
}
