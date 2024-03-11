using APICatalogo.Context;
using APICatalogo.Filters;
using APICatalogo.Models;
using APICatalogo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    //injeção de depedencia
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public CategoriasController(AppDbContext context, IConfiguration config, ILogger<CategoriasController> logger)
    {
        _context = context;
        _configuration = config;
        _logger = logger;
    }

    [HttpGet("saudacao/{nome}")]
    public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuServico, string nome)
    {
        return meuServico.Saudacao(nome);
    }

    // se coloca /primeiro ele ignora e a rota fica /primeiro e nao /categoria/primeiro
    [HttpGet("produtos")] // /Categorias/produtos
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos() //retornar todas as categorias e os produtos
    {
        _logger.LogInformation("===== GET api/categoria =====");
        //return _context.Categorias.Include(p => p.Produtos).ToList(); //inclui todos os produtos relacionado
        return _context.Categorias.Include(p => p.Produtos).Where(c => c.CategoriaId <= 5).ToList();
    }   

    [HttpGet]
    [ServiceFilter(typeof(ApiloggingFilter))] //executa antes da action
    public ActionResult<IEnumerable<Categoria>> Get()
    {
        try
        {
            return _context.Categorias.AsNoTracking().ToList(); //tornar a consulta não rastreada
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um error no servidor.");
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<Categoria> Get(int id) 
    {
        try
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria == null)
            {
                return NotFound("Categoria não encontrado.");
            }

            return Ok(categoria);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um error no servidor.");
        }
    }

    [HttpPost]
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterCategoria",
            new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest("Dados inválidos.");
        }

        _context.Entry(categoria).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<Categoria> Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);

        if (categoria == null)
        {
            return NotFound("Categoria não encontrada.");
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return Ok(categoria);
    }
}
