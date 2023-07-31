using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetHome.DataAccess.Interfaces.Users;
using SweetHome.DataAccess.Repositories.Users;
using SweetHome.DataAccess.Utils;
using SweetHome.Domain.Entities.Users;
using SweetHome.Service.Common.Helpers;
using SweetHome.Service.Dtos.Users;
using SweetHome.Service.Interfaces.Users;

namespace SweetHome.WebApi.Controllers.UsersController
{

    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly int MaxPageSize = 30;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet("GetAll")]

        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));


        [HttpGet]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdAsync(long Id)
            => Ok(await _service.GetByIdAsync(Id));


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpDelete]

        public async Task<IActionResult> DeleteAsync(long userId)
            => Ok(await _service.DeleteAsync(userId));

    }

}
