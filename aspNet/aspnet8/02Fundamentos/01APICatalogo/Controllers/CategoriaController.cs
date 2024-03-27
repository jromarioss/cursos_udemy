using _01APICatalogo.Context;
using _01APICatalogo.Filters;
using _01APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public CategoriaController(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;

    }

    [HttpGet("lerArquivo")]
    public string GetValores()
    {
        var valor1 = _configuration["chave1"];
        var valor2 = _configuration["chave2"];
        var secao = _configuration["secao1:chave2"];

        return $"{valor1}, {valor2}, {secao}";
    }
    // Categoria/getCategoriaEProduto
    [HttpGet("getCategoriaEProduto")]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public ActionResult<IEnumerable<Categoria>> GetCategoriaEProduto()
    {
        try
        {
            var categoria = _context.Categorias.AsNoTracking().Include(p => p.Produtos).ToList();

            if (categoria is null)
            {
                return NotFound("Categoria não encontrado");
            }

            return Ok(categoria);
        }
        catch (Exception)
        {

            throw;
        }
    }
    // Categoria/getCategoria
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
    // Categoria/getCategoriaPorId
    [HttpGet("getCategoriaPorId/{id:int:min(1)}")]
    public ActionResult<Categoria> GetCategoriaPorId(int id)
    {
        var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(p => p.CategoriaId == id);

        if (categoria is null)
        {
            return NotFound("Categoria não encontrado");
        }

        return Ok(categoria);
    }
    // Categoria/PostCategoria
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
    // Categoria/putCategoria
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
    // Categoria/deleteProduto
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
