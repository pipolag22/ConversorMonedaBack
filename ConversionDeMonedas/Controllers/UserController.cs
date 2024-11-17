using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ConversionDeMonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Registro")]
        public IActionResult Create(CreateUserDto dto)
        {
            try
            {
                _userService.Create(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Creado correctamente");
        }
    }
}
