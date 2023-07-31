using Dapper;
using Npgsql;
using System.ComponentModel;

namespace SweetHome.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=SweetHome; User Id=postgres; Password=12345;");
    }
}
