using DocumentFormat.OpenXml.Bibliography;
using SweetHome.DataAccess.Utils;
using SweetHome.Domain.Entities.Homes;
using SweetHome.Service.Dtos.Homes;

namespace SweetHome.Service.Interfaces.Homes;

public interface IHomeService
{
    public Task<bool> CreateAsync(HomeCreateDto dto);


    public Task<IList<Home>> GetAllAsync(PaginationParams @params);

    public Task<bool> DeleteAsync(long apartmentId);

    public Task<long> CountAsync();


    public Task<bool> UpdateAsync(long apartmentId, HomeUpdateDto dto);


    public Task<Home> GetByIdAsync(long id);
}
