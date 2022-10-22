using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiNet6.Data;
using WebApiNet6.Models;

namespace WebApiNet6.Controllers
{
    [ApiController]
    [Route("tarefas")]
    public class TarefaController : ControllerBase
    {
        private readonly DataContext _context;

        public TarefaController(DataContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() => Ok(_context.Tarefas.AsNoTracking().ToList());

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                var result = _context.Tarefas.AsNoTracking().FirstOrDefault(x => x.Id == id);
                if (result == null)
                    return NotFound();

                return Ok(_context.Tarefas.AsNoTracking().Where(a => a.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarefa tarefa)
        {
            try
            {
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
                return Created($"{tarefa.Id}", tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Tarefa tarefa)
        {
            try
            {
                //REIDRATAÇÃO
                var result = _context.Tarefas.FirstOrDefault(x => x.Id == id);

                if (result == null)
                    return NotFound();

                result.Titulo = tarefa.Titulo;
                result.Feito = tarefa.Feito;

                _context.Update(result);
                _context.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var result = _context.Tarefas.FirstOrDefault(x => x.Id == id);
                if (result == null)
                    return NotFound();

                _context.Remove(result);
                _context.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
