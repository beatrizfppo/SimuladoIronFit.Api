using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimuladoIronFit.Api.Data;
using SimuladoIronFit.Api.Models;
using SimuladoIronFit.Api.Models.DTOs;

namespace SimuladoIronFit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/alunos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoDto>>> GetAlunos()
        {
            return await _context.Alunos.Select(a => new AlunoDto
            {
                Id = a.Id,
                Nome = a.Nome,
                Cpf = a.Cpf,
                PersonalId = a.PersonalId
            }).ToListAsync();
        }

        // GET: api/alunos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoDto>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return new AlunoDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Cpf = aluno.Cpf,
                PersonalId = aluno.PersonalId
            };

        }

        // POST: api/alunos
        [HttpPost]
        public async Task<ActionResult<AlunoDto>> CreateAluno(AlunoDto alunoDto)
        {

            var personalExiste = await _context.Personais.AnyAsync(p => p.Id == alunoDto.PersonalId);

            if (!personalExiste)
            {
                return BadRequest(new { mensagem = $"Não existe nenhum Personal cadastrado com o ID {alunoDto.PersonalId}." });
            }

            var aluno = new Aluno
            {
                Nome = alunoDto.Nome,
                Cpf = alunoDto.Cpf,
                PersonalId = alunoDto.PersonalId
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, alunoDto);
        }

        //PUT: api/alunos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, AlunoDto alunoDto)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            aluno.Nome = alunoDto.Nome;
            aluno.Cpf = alunoDto.Cpf;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/alunos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}