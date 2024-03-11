using _01APICatalogo.Context;
using _01APICatalogo.Models;
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

    [HttpGet("getProduto")]
    public ActionResult<IEnumerable<Produto>> GetProdutos()
    {
        var produtos = _context.Produtos.ToList();

        if (produtos is null)
        {
            return NotFound("Produtos não encontrado");
        }

        return produtos;
    }

    [HttpGet("getProdutoPorId/{id:int}")]
    public ActionResult<Produto> GetProdutoPorId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

        if (produto is null)
        {
            return NotFound("Produtos não encontrado");
        }

        return produto;
    }

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
