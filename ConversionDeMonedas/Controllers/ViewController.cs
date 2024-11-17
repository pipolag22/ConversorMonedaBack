using ConversionDeMonedas.Entities;
using ConversionDeMonedas.Models.Dtos;
using ConversionDeMonedas.Models.Enum;
using ConversionDeMonedas.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConversionDeMonedas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ViewController : ControllerBase
    {
        private readonly ViewService _viewService;

        public ViewController(ViewService viewService)
        {
            _viewService = viewService;
        }

        [HttpPut("CambiarSub")]
        public IActionResult UpdateSub(Suscripcion sub)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);

            try
            {
                _viewService.UpdateSub(userId, sub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok("Editado Correctamente");
        }

        [HttpGet("VerSub")]
        public string GetSub()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);

            string sub = _viewService.GetSub(userId);
            return sub;
        }

        [HttpGet("VerTotalConversiones")]
        public int GetTotalConvert()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);

            int TotalConvert = _viewService.GetTotalConvert(userId);
            return TotalConvert;
        }

        [HttpGet("VerMonedasUsuario")]
        public IActionResult GetUserCoins()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);

            try
            {
                List<MonedasUser> Monedas = _viewService.GetUsersCoins(userId);
                return Ok(Monedas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("VerMonedaUserById")]
        public IActionResult GetUserCoinById(int CoinId)
        {
            try
            {
                MonedaDto moneda = _viewService.GetUserCoinById(CoinId);
                return Ok(moneda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("VerMonedasDefault")]
        public IActionResult GetDefaultCoins()
        {
            try
            {
                List<MonedasDefault> Monedas = _viewService.GetDefaultCoins();
                return Ok(Monedas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("VerMonedasFavoritas")]
        public IActionResult GetFavsCoins()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);

            try
            {
                List<Favoritas> Monedas = _viewService.GetFavsCoins(userId);
                return Ok(Monedas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("VerFavoritaByLeyenda")]
        public IActionResult GetFavCoinByLeyenda(string leyenda)
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);

            try
            {
                Favoritas res = _viewService.GetFavCoinByLeyenda(userId, leyenda);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return NotFound("Moneda no encontrada en favoritos.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
