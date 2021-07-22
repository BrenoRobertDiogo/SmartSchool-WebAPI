using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;
using System;
using System.Threading.Tasks;

namespace SmartSchool_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository repo;

        public AlunoController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await this.repo.GetAllAlunosAsync(true);
                return Ok(result);
            }
            catch (Exception e)
            {


                return BadRequest($"Erro {e}");
            }
        }
        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoId)
        {
            try
            {
                var result = await this.repo.GetAlunoAsyncById(AlunoId, true);
                return Ok(result);
            }
            catch (Exception e)
            {


                return BadRequest($"Erro {e}");
            }
        }

        [HttpGet("ByDisciplina/{disciplinaId}")]
        public async Task<IActionResult> GetByDisciplinaId(int disciplinaId)
        {
            try
            {
                var result = await this.repo.GetAlunosAsyncByDisciplinaId(disciplinaId, true);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest($"Erro {e}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Aluno model)
        {
            try
            {
                this.repo.Add(model);
                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro {e.Message}");
            }
            return BadRequest("Erro não esperado!");
        }
        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> Put(int AlunoId, Aluno model)
        {
            try
            {
                var aluno = await this.repo.GetAlunoAsyncById(AlunoId, false);
                if (aluno == null) return NotFound();

                this.repo.Update(model);
                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return BadRequest($"Erro {e.Message}");
            }
            return BadRequest("Erro não esperado!");
        }

    } // Fim classe
}     // Fim namespace