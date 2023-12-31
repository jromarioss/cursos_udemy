﻿using ApiCatalago.Context;

namespace ApiCatalago.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ProdutoRepository _produtoRepository;
    private CategoriaRepository _categoriaRepository;
    public AppDbContext _context;

    public UnitOfWork(AppDbContext context) // injeta o dbcontext
    {
        _context = context;
    }

    public IProdutoRepository ProdutoRepository
    {
        get { return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context); }
    }

    public ICategoriaRepository CategoriaRepository
    {
        get {  return _categoriaRepository ?? _categoriaRepository ?? new CategoriaRepository(_context); }
    }

    public void Commit() // salva
    {
        _context.SaveChanges();
    }

    public void Dispose() // libera os recursos usado
    {
        _context.Dispose();
    }
}
