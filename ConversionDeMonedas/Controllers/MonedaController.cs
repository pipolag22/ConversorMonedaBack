using ConversionDeMonedas.Data;
using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConversionDeMonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoinController : ControllerBase
    {
        private readonly MonedaService _coinService; ConversionDeMonedasContext _CDMContext;

        public CoinController(MonedaService coinService, ConversionDeMonedasContext cdmContext)
        {
            _coinService = coinService;
            _CDMContext = cdmContext;
        }

        [HttpGet("Convertir")]

        public IActionResult Convert([FromQuery] double amount, [FromQuery] ToConvert toConvert) 
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            Usuario? usuario = _CDMContext.usuario.SingleOrDefault(u => u.Id == userId);

            if (usuario.TotalConversiones != 0)
            {
                try
                {
                    double result = _coinService.Convert(usuario, amount, toConvert);
                    usuario.TotalConversiones -= 1;
                    _CDMContext.SaveChanges();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
            else
            {
                double result = -1;
                return Ok(result);
            }
        }

        [HttpPost("CrearMoneda")]
        public IActionResult CreateCoin([FromBody] CreateAndUpdateCoinDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            try
            {
                _coinService.CreateCoin(userId, dto);
                return Ok("Creada Correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("EditarMoneda")]
        public IActionResult UpdateCoin([FromQuery] int CoinId, [FromQuery] string leyenda, [FromBody] CreateAndUpdateCoinDto dto)
        {
            try
            {
                _coinService.UpdateCoin(CoinId, leyenda, dto);
                return Ok("Moneda actualizada correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la moneda: {ex.Message}");
                return BadRequest("Error al actualizar la moneda");
            }
        }

        [HttpDelete("EliminarMoneda")]

        public IActionResult DeleteCoin(int CoinId, string leyenda)
        {
            try
            {
                _coinService.DeleteCoin(CoinId, leyenda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Eliminada Correctamente");
        }

        [HttpPost("AgregarFavorita")]

        public IActionResult AddFavCoin(AddFavoriteDto favDto)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            try
            {
                _coinService.AddFavCoin(userId, favDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Agregada Correctamente");
        }

        [HttpDelete("BorrarFavorita")]

        public IActionResult DeleteFavCoin(int monedaId) 
        {
            try
            {
                _coinService.DeleteFavCoin(monedaId);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Eliminada correctamente");
        }
    }
}