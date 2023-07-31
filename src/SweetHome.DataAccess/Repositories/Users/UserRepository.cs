using Dapper;
using SweetHome.DataAccess.Interfaces.Users;
using SweetHome.DataAccess.Utils;
using SweetHome.DataAccess.ViewModels;
using SweetHome.Domain.Entities.Users;

namespace SweetHome.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from users";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(ism, familiya, tel_nomer, telnomerconfirmed, parol, identity_role, updatedat, createdat) " +
                "VALUES (@Ism, @Familiya, @TelNomer, @TelNomerConfirmed, @Parol, @IdentityRole, @UpdatedAt, @CreatedAt);";
            return await _connection.ExecuteAsync(query, entity);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeliteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from users where id = @Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<UsersViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from users " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<UsersViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<UsersViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<UsersViewModel> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from users where id = {id}";
            var result = await _connection.QuerySingleAsync<UsersViewModel>(query);
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByPhoneAsync(string phone)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM users where tel_nomer = '{phone}' ;";
            var data = await _connection.QuerySingleAsync<User>(query);
            return data;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<(int ItemsCount, IList<UsersViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.users SET ism = @Ism, familiya = @Familiya, " +
                "tel_nomer = @TelNomer, parol = @Parol, identity_role = @IdentityRole, " +
                "updatedat = UpdatedAt, createdat = @CreatedAt " +
                $"WHERE id = {id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
