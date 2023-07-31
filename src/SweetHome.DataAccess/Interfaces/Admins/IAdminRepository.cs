using SweetHome.DataAccess.Common.Interfaces;
using SweetHome.Domain.Entities.Users;

namespace SweetHome.DataAccess.Interfaces.Admins;

public interface IAdminRepository : IRepository<User, User>,
    IGetAll<User>
{
}
