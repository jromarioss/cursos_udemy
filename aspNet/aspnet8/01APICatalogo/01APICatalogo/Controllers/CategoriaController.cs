using _01APICatalogo.Context;
using _01APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("getCategoriaEProduto")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriaEProduto()
    {
        var categoria = _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();

        if (categoria is null)
        {
            return NotFound("Categoria não encontrado");
        }

        return Ok(categoria);
    }

    [HttpGet("getCategoria")]
    public ActionResult<IEnumerable<Categoria>> GetCategoria()
    {
        try
        {
            var categoria = _context.Categorias.AsNoTracking().ToList();

            if (categoria is null)
            {
                return NotFound("Categoria não encontrado");
            }

            return Ok(categoria);
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    [HttpGet("getCategoriaPorId/{id:int}")]
    public ActionResult<Categoria> GetCategoriaPorId(int id)
    {
        var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

        if (categoria is null)
        {
            return NotFound("Categoria não encontrado");
        }

        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult PostCategoria([FromBody] Categoria categoria)
    {
        if (categoria == null)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return new CreatedAtRouteResult("getCategoriaPorId", new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("putCategoria/{id:int}")]
    public ActionResult PutCategoria(int id, [FromBody] Categoria categoria)
    {
        if (categoria == null && id != categoria.CategoriaId)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(categoria);
    }

    [HttpDelete("deleteProduto/{id:int}")]
    public ActionResult DeleteProduto(int id)
    {
        if (id < 0)
        {
            return BadRequest("Dados inválido.");
        }

        var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

        if (categoria == null)
        {
            return NotFound("Categoria não encontrado");
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return Ok();
    }
}
