using Microsoft.AspNetCore.Http;

namespace SweetHome.Service.Interfaces.Commons;

public interface IFileService
{
    //return sub path of this image
    public Task<string> UploadImageAsync(IFormFile image);


    public Task<bool> DeleteImageAsync(string subpath);

    //return sub path of this avatar
    public Task<string> UploadAvatarAsync(IFormFile avatar);




    public Task<bool> DeleteAvatarAsync(string subpath);
}
