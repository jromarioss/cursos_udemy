using ApiCatalago.Context;
using ApiCatalago.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Controllers;

// rota /produtos
[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context) // instância o contexto
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get() // o actionresult permite ter varios tipo de reposta como notfound ok...
    {
        try
        {
            var categoria = _context.Categorias.AsNoTracking().ToList();

            if (categoria is null)
            {
                return NotFound();
            }

            return categoria;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpGet("produtos")] // /categorias/produtos
    public ActionResult<IEnumerable<Categoria>> GetCategoriasEProdutos()
    {
        try
        {
            return _context.Categorias.Include(p => p.Produtos).ToList(); // incluí os produtos relacionado
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    // /produtos/id
    [HttpGet("{id:int}", Name = "obter-produto")] // rota nomeada /produtos/obter-produto
    public ActionResult<Categoria> Get(int id)
    {
        try
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Categoria não encontrado.");
            }

            return categoria;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        try
        {
            if (categoria is null)
            {
                return BadRequest("Dados inválido.");
            }

            _context.Categorias.Add(categoria); // chama o contexto a tabela produtos e adiciona
            _context.SaveChanges(); // persiste os dado na DB

            // chama a rota e com o produto criado
            return new CreatedAtRouteResult("obter-produto",
                new { id = categoria.CategoriaId }, categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        try
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Produto inválido.");
            }

            // usa o entry e define o estado para modificado
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        try
        {
            // busca no banco o id
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria is null)
            {
                return NotFound("Produto não encontrado.");
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error no servidor.");
        }
    }
}
