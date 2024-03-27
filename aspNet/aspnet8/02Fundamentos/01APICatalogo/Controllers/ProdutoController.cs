using _01APICatalogo.Context;
using _01APICatalogo.Models;
using _01APICatalogo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01APICatalogo.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProdutoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("saudacao")]
    public ActionResult<string> GetSaudacao([FromServices] IMeuServico meuServico, string nome)
    {
        return meuServico.Saudacao(nome);
    }
    // Produto/getProduto
    [HttpGet("getProduto")]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        var produtos = await _context.Produtos.ToListAsync();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrado");
        }

        return produtos;
    }
    // Produto/getProdutoPorId
    [HttpGet("getProdutoPorId/{id:int}")]
    public async Task<ActionResult<Produto>> GetProdutoPorId([FromQuery] int id)
    {
        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.ProdutoId == id);

        if (produto is null)
        {
            return NotFound("Produtos não encontrado");
        }

        return produto;
    }
    // Produto/PostProduto
    [HttpPost]
    public ActionResult PostProduto([FromBody]Produto produto)
    {
        if (produto == null)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return new CreatedAtRouteResult("getProdutoPorId", new { id = produto.ProdutoId }, produto);
    }
    // Produto/putProduto
    [HttpPut("putProduto/{id:int}")]
    public ActionResult PutProduto(int id, [FromBody] Produto produto)
    {
        if (produto == null && id != produto.ProdutoId)
        {
            return BadRequest("Dados inválido.");
        }

        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(produto);
    }
    // Produto/deleteProduto
    [HttpDelete("deleteProduto/{id:int}")]
    public ActionResult DeleteProduto(int id)
    {
        if (id < 0)
        {
            return BadRequest("Dados inválido.");
        }

        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if (produto  == null)
        {
            return NotFound("Produto não encontrado");
        }

        _context.Produtos.Remove(produto);
        _context.SaveChanges();

        return Ok();
    }
}
