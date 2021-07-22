using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

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
        [HttpGet("ByAluno/{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoId) 
        {
            try
            {
                var result = await this.repo.GetAlunoAsyncById(AlunoId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Professor prof) 
        {
            try
            {
                this.repo.Add(prof);
                if (await this.repo.SaveChangesAsync())
                {
                    return Ok(prof);
                }
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
            return BadRequest("Erro inesperado!");
        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try
            {
                var Professor = await this.repo.GetProfessorAsyncById(ProfessorId, false);
                if (Professor == null) return NotFound();

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

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId, Professor model)
        {
            try
            {
                var Professor = await this.repo.GetProfessorAsyncById(ProfessorId, false);
                if (Professor == null) return NotFound();

                this.repo.Delete(model);
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
}     // Fim Namespace