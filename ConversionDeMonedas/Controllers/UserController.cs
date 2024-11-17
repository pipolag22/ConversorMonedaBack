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
                return Ok("Creado correctamente");
            }
            catch (Exception ex)
            {
                // Enviar un mensaje claro si el email ya está registrado
                if (ex.Message == "El correo electrónico ya está registrado.")
                {
                    return Conflict(new { message = ex.Message });
                }
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
