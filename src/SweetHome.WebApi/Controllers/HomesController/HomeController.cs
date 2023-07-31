using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetHome.DataAccess.Utils;
using SweetHome.Service.Dtos.Homes;
using SweetHome.Service.Interfaces.Homes;
using SweetHome.Service.Validators.Dtos.Homes;

namespace SweetHome.WebApi.Controllers.HomesController
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _service;
        private readonly int MaxPageSize = 30;
        public HomeController(IHomeService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));

        [HttpPut("{Id}")]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> UpdateAsync(long homeId, [FromForm] HomeUpdateDto dto)
        {
            var updateValidator = new HomeUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(homeId, dto));
            else return BadRequest(validationResult.Errors);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long Id)
            => Ok(await _service.GetByIdAsync(Id));


        [HttpPost]
        //[Authorize(Roles = "Admin,User")]

        public async Task<IActionResult> CreateAsyncs([FromForm] HomeCreateDto dto)
        {
            var Valid = new HomeCreateValidator();
            var result = Valid.Validate(dto);
            if (result.IsValid) return Accepted(await _service.CreateAsync(dto));
            else { return BadRequest(result.Errors); }
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> DeleteAsync(long homeId)
            => Ok(await _service.DeleteAsync(homeId));
    }
}
