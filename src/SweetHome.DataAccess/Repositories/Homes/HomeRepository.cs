using Dapper;
using DocumentFormat.OpenXml.Bibliography;
using SweetHome.DataAccess.Interfaces.Homes;
using SweetHome.DataAccess.Utils;
using SweetHome.DataAccess.ViewModels;
using SweetHome.Domain.Entities.Homes;

namespace SweetHome.DataAccess.Repositories.Homes;

public class HomeRepository : BaseRepository, IHomeRepository
{ 
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from homes";
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

    public async Task<int> CreateAsync(Home entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.homes(" +
                "manzil, xonalar_soni, etaj, etaj_zdaniya, remont, narx, narx_variant, tavsif, " +
                "rasm_1, rasm_2, rasm_3, rasm_4, rasm_5, rasm_6, rasm_7, rasm_8, updatdat, createdat, users_id)" +
                "VALUES (@Manzil, @Xonalar_soni, @Etaj, @Etaj_zdaniya, @Remont, @Narx, @Narx_variant, @Tavsif, " +
                "@Rasm_1, @Rasm_2, @Rasm_3, @Rasm_4, @Rasm_5, @Rasm_6, @Rasm_7, @Rasm_8, @Updatdat, @Createdat, @Users_id);";

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

    public async Task<int> DeliteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"DELETE FROM homes WHERE id=@Id";
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

    public async Task<IList<Home>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM homes order by id desc " +
                $"offset {0} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Home>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<Home>();

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Home> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM homes where id = @Id";
            var result = await _connection.QuerySingleAsync<Home>(query, new { Id = id });
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

    public Task<(int ItemsCount, IList<Home>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Home entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "UPDATE public.homes " +
                " SET manzil = @Manzil, xonalar_soni = @Xonalar_soni, etaj = @Etaj, etaj_zdaniya = @Etaj_zdaniya, " +
                "remont = @Remont, narx = @Narx, narx_variant = @Narx_variant, tavsif = @Tavsif, rasm_1 = @Rasm_1, " +
                "rasm_2 = @Rasm_2, rasm_3 = @Rasm_3, rasm_4 = @Rasm_4, rasm_5 = @Rasm_5, rasm_6 = @Rasm_6, rasm_7 = @Rasm_7, " +
                "rasm_8 = @Rasm_8, updatdat = @Updatdat, createdat = @Createdat, users_id = @Users_id " +
                $" WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {

            return 0;
        }
        finally { await _connection.CloseAsync(); }
    }
}
