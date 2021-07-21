using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using System;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {

        public AlunoController(IRepository repo) 
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok("Breno testes ;)");
            }
            catch (Exception e)
            {

                
            return BadRequest($"Erro {e}");
            }
        }
    }
}