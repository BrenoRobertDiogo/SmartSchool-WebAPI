using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository repo;

        public ProfessorController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.repo.GetAllProfessoresAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int ProfId) 
        {
            try
            {
                var result = await this.repo.GetProfessorAsyncById(ProfId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }

    } // Fim classe
}     // Fim Namespace