using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using Microsoft.Extensions.Caching.Memory;
using SweetHome.DataAccess.Interfaces.Homes;
using SweetHome.DataAccess.Utils;
using SweetHome.Domain.Entities.Homes;
using SweetHome.Domain.Exceptions.Files;
using SweetHome.Domain.Exceptions.Homes;
using SweetHome.Service.Common.Helpers;
using SweetHome.Service.Dtos.Homes;
using SweetHome.Service.Interfaces.Commons;
using SweetHome.Service.Interfaces.Homes;

namespace SweetHome.Service.Services.Homes;

public class HomeService : IHomeService
{
    private readonly IHomeRepository _repository;
    private readonly IFileService _fileServise;
    private readonly IMemoryCache _memoryCache;
    private const int second = 30;
    public HomeService(IHomeRepository apartmentRepository,
        IFileService fIleService,
        IMemoryCache memorycache)
    {
        this._repository = apartmentRepository;
        this._fileServise = fIleService;
        this._memoryCache = memorycache;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();


    public async Task<bool> CreateAsync(HomeCreateDto dto)
    {
        string rasm_1 = await _fileServise.UploadImageAsync(dto.Rasm_1);
        string rasm_2 = await _fileServise.UploadImageAsync(dto.Rasm_2);
        string rasm_3 = await _fileServise.UploadImageAsync(dto.Rasm_3);

        string rasm_4 = await _fileServise.UploadImageAsync(dto.Rasm_4);
        string rasm_5 = await _fileServise.UploadImageAsync(dto.Rasm_5);
        string rasm_6 = await _fileServise.UploadImageAsync(dto.Rasm_6);
        string rasm_7 = await _fileServise.UploadImageAsync(dto.Rasm_7);
        string rasm_8 = await _fileServise.UploadImageAsync(dto.Rasm_8);

        Home home = new Home()
        {

            Manzil = dto.Manzil,
            Xonalar_soni = dto.Xonalar_soni,
            Etaj = dto.Etaj,
            Etaj_zdaniya = dto.Etaj_zdaniya,
            Remont = dto.Remont,
            Narx = dto.Narx,
            Narx_variant = dto.Narx_variant,
            Tavsif = dto.Tavsif,
            Rasm_1 = rasm_1,
            Rasm_2 = rasm_2,
            Rasm_3 = rasm_3,
            Rasm_4 = rasm_4,
            Rasm_5 = rasm_5,
            Rasm_6 = rasm_6,
            Rasm_7 = rasm_7,
            Rasm_8 = rasm_8,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(home);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long homeId)
    {
        var home = await _repository.GetByIdAsync(homeId);
        if (home is null) throw new HomeNotFountException();

        var result1 = await _fileServise.DeleteImageAsync(home.Rasm_1);
        var result2 = await _fileServise.DeleteImageAsync(home.Rasm_2);
        var result3 = await _fileServise.DeleteImageAsync(home.Rasm_3);
        var result4 = await _fileServise.DeleteImageAsync(home.Rasm_4);
        var result5 = await _fileServise.DeleteImageAsync(home.Rasm_5);
        var result6 = await _fileServise.DeleteImageAsync(home.Rasm_6);
        var result7 = await _fileServise.DeleteImageAsync(home.Rasm_7);
        var result8 = await _fileServise.DeleteImageAsync(home.Rasm_8);

        var dbResult = await _repository.DeliteAsync(homeId);
        return dbResult > 0;

    }
    public async Task<bool> UpdateAsync(long homeId, HomeCreateDto dto)
    {

        var home = await _repository.GetByIdAsync(homeId);
        if (home is null) throw new HomeNotFountException();

        // parse new items to category

        home.Manzil = dto.Manzil;
        home.Xonalar_soni = dto.Xonalar_soni;
        home.Etaj = dto.Etaj;
        home.Etaj_zdaniya = dto.Etaj_zdaniya;
        home.Remont = dto.Remont;
        home.Narx = dto.Narx;
        home.Narx_variant = dto.Narx_variant;
        home.Tavsif = dto.Tavsif;
        if (dto.Rasm_1 is not null)
        {
            var result1 = await _fileServise.DeleteImageAsync(home.Rasm_1);

            string newImagePath1 = await _fileServise.UploadImageAsync(dto.Rasm_1);
            
            home.Rasm_1 = newImagePath1;
        }
        if (dto.Rasm_2 is not null)
        {
            var result1 = await _fileServise.DeleteImageAsync(home.Rasm_2);

            string newImagePath2 = await _fileServise.UploadImageAsync(dto.Rasm_2);

            home.Rasm_2 = newImagePath2;
        }
        if (dto.Rasm_3 is not null)
        {
            var result3 = await _fileServise.DeleteImageAsync(home.Rasm_3);

            string newImagePath3 = await _fileServise.UploadImageAsync(dto.Rasm_3);

            home.Rasm_3 = newImagePath3;
        }
        if (dto.Rasm_4 is not null)
        {
            var result4 = await _fileServise.DeleteImageAsync(home.Rasm_4);

            string newImagePath4 = await _fileServise.UploadImageAsync(dto.Rasm_4);

            home.Rasm_4 = newImagePath4;
        }
        if (dto.Rasm_5 is not null)
        {
            var result5 = await _fileServise.DeleteImageAsync(home.Rasm_5);

            string newImagePath5 = await _fileServise.UploadImageAsync(dto.Rasm_5);

            home.Rasm_5 = newImagePath5;
        }
        if (dto.Rasm_6 is not null)
        {
            var result6 = await _fileServise.DeleteImageAsync(home.Rasm_6);

            string newImagePath6 = await _fileServise.UploadImageAsync(dto.Rasm_6);

            home.Rasm_6 = newImagePath6;
        }
        if (dto.Rasm_7 is not null)
        {
            var result7 = await _fileServise.DeleteImageAsync(home.Rasm_7);

            string newImagePath7 = await _fileServise.UploadImageAsync(dto.Rasm_7);

            home.Rasm_7 = newImagePath7;
        }
        if (dto.Rasm_8 is not null)
        {
            var result8 = await _fileServise.DeleteImageAsync(home.Rasm_8);

            string newImagePath8 = await _fileServise.UploadImageAsync(dto.Rasm_8);

            home.Rasm_8 = newImagePath8;
        }
        //else category old image have to save

        home.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(homeId, home);
        return dbResult > 0;
    }
    public async Task<IList<Home>> GetAllAsync(PaginationParams @params)
    {
        var home = await _repository.GetAllAsync(@params);
        return home;
    }

    public async Task<Home> GetByIdAsync(long homeId)
    {
        if (_memoryCache.TryGetValue(homeId, out Home cachehome))
        {
            return cachehome;
        }
        else
        {
            var home = await _repository.GetByIdAsync(homeId);
            if (home is null) throw new HomeNotFountException();
            _memoryCache.Set(homeId, home, TimeSpan.FromSeconds(second));
            return home;

        }
    }

    public async Task<bool> UpdateAsync(long homeId, HomeUpdateDto dto)
    {
        var home = await _repository.GetByIdAsync(homeId);
        if (home is null) throw new HomeNotFountException();

        // parse new items to category

        home.Manzil = dto.Manzil;
        home.Xonalar_soni = dto.Xonalar_soni;
        home.Etaj = dto.Etaj;
        home.Etaj_zdaniya = dto.Etaj_zdaniya;
        home.Remont = dto.Remont;
        home.Narx = dto.Narx;
        home.Narx_variant = dto.Narx_variant;
        home.Tavsif = dto.Tavsif;
        if (dto.Rasm_1 is not null)
        {
            var result1 = await _fileServise.DeleteImageAsync(home.Rasm_1);

            string newImagePath1 = await _fileServise.UploadImageAsync(dto.Rasm_1);

            home.Rasm_1 = newImagePath1;
        }
        if (dto.Rasm_2 is not null)
        {
            var result1 = await _fileServise.DeleteImageAsync(home.Rasm_2);

            string newImagePath2 = await _fileServise.UploadImageAsync(dto.Rasm_2);

            home.Rasm_2 = newImagePath2;
        }
        if (dto.Rasm_3 is not null)
        {
            var result3 = await _fileServise.DeleteImageAsync(home.Rasm_3);

            string newImagePath3 = await _fileServise.UploadImageAsync(dto.Rasm_3);

            home.Rasm_3 = newImagePath3;
        }
        if (dto.Rasm_4 is not null)
        {
            var result4 = await _fileServise.DeleteImageAsync(home.Rasm_4);

            string newImagePath4 = await _fileServise.UploadImageAsync(dto.Rasm_4);

            home.Rasm_4 = newImagePath4;
        }
        if (dto.Rasm_5 is not null)
        {
            var result5 = await _fileServise.DeleteImageAsync(home.Rasm_5);

            string newImagePath5 = await _fileServise.UploadImageAsync(dto.Rasm_5);

            home.Rasm_5 = newImagePath5;
        }
        if (dto.Rasm_6 is not null)
        {
            var result6 = await _fileServise.DeleteImageAsync(home.Rasm_6);

            string newImagePath6 = await _fileServise.UploadImageAsync(dto.Rasm_6);

            home.Rasm_6 = newImagePath6;
        }
        if (dto.Rasm_7 is not null)
        {
            var result7 = await _fileServise.DeleteImageAsync(home.Rasm_7);

            string newImagePath7 = await _fileServise.UploadImageAsync(dto.Rasm_7);

            home.Rasm_7 = newImagePath7;
        }
        if (dto.Rasm_8 is not null)
        {
            var result8 = await _fileServise.DeleteImageAsync(home.Rasm_8);

            string newImagePath8 = await _fileServise.UploadImageAsync(dto.Rasm_8);

            home.Rasm_8 = newImagePath8;
        }
        //else category old image have to save

        home.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(homeId, home);
        return dbResult > 0;
    }
}
