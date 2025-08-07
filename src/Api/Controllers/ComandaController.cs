using Domain.Abstractions;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("RestAPIFurb")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaService _comandaService;

        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpGet("comandas")]
        public async Task<ActionResult<List<ComandaSummaryResponse>>> Get()
        {
            try
            {
                var result = await _comandaService.Get();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("comandas/{id}")]
        public async Task<ActionResult<ComandaResponse>> GetById(int id)
        {
            try
            {
                var result = await _comandaService.GetById(id);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("comandas")]
        public async Task<ActionResult<ComandaResponse>> Create(ComandaRequest request)
        {
            try
            {
                var result = await _comandaService.CreateAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("comandas/{id}")]
        public async Task Update()
        {

        }

        [HttpDelete("comandas/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var success = await _comandaService.DeleteAsync(id);

                if (!success)
                    return BadRequest();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
