using Domain.Abstractions;
using Domain.DTOs;
using Domain.Models;
using Infra.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ComandaService : IComandaService
    {
        private readonly DataContext _context;

        public ComandaService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ComandaSummaryResponse>> Get()
        {
            return await _context.Comandas
                .Select(x => new ComandaSummaryResponse()
                {
                    IdUsuario = x.Id,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.NomeUsuario
                }).ToListAsync();
        }

        public async Task<ComandaResponse?> GetById(int id)
        {
            return await _context.Comandas
                .Include(c => c.ComandasProdutos)
                    .ThenInclude(cp => cp.Produto)
                .Select(x => new ComandaResponse()
                {
                    Id = x.Id,
                    IdUsuario = x.IdUsuario,
                    NomeUsuario = x.NomeUsuario,
                    TelefoneUsuario = x.TelefoneUsuario,
                    Produtos = x.ComandasProdutos
                    .Select(cp =>
                        new ProdutoResponse
                        {
                            Id = cp.Produto.Id,
                            Nome = cp.Produto.Nome,
                            Preco = cp.Produto.Preco
                        }).ToList()
                })
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ComandaResponse> CreateAsync(ComandaRequest request)
        {
            var comanda = new Comanda
            {
                IdUsuario = request.IdUsuario,
                NomeUsuario = request.NomeUsuario,
                TelefoneUsuario = request.TelefoneUsuario,
            };

            _context.Comandas.Add(comanda);
            await _context.SaveChangesAsync();

            foreach (var produtoDto in request.Produtos)
            {
                Produto? produto;

                if (produtoDto.Id > 0)
                {
                    produto = await _context.Produtos.FindAsync(produtoDto.Id);

                    if (produto != null)
                    {
                        produto.Nome = produtoDto.Nome;
                        produto.Preco = produtoDto.Preco;
                        _context.Produtos.Update(produto);
                    }
                    else
                    {
                        produto = new Produto
                        {
                            Nome = produtoDto.Nome,
                            Preco = produtoDto.Preco
                        };

                        _context.Produtos.Add(produto);
                        await _context.SaveChangesAsync();
                    }
                }
                else
                {
                    produto = new Produto
                    {
                        Nome = produtoDto.Nome,
                        Preco = produtoDto.Preco
                    };

                    _context.Produtos.Add(produto);
                    await _context.SaveChangesAsync();
                }

                var comandaProduto = new ComandaProduto
                {
                    ComandaId = comanda.Id,
                    ProdutoId = produto.Id
                };

                _context.ComandasProdutos.Add(comandaProduto);
            }

            await _context.SaveChangesAsync();

            return await GetById(comanda.Id);
        }

        public async Task<ComandaResponse?> UpdateAsync(int id, UpdateComandaRequest request)
        {
            var comanda = await _context.Comandas
                .Include(c => c.ComandasProdutos)
                    .ThenInclude(cp => cp.Produto)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comanda is null)
                return null;

            comanda.IdUsuario = request.IdUsuario ?? comanda.IdUsuario;
            comanda.NomeUsuario = request.NomeUsuario ?? comanda.NomeUsuario;
            comanda.TelefoneUsuario = request.TelefoneUsuario ?? comanda.TelefoneUsuario;

            if (request.Produtos is not null)
            {
                var idsEnviados = request.Produtos.Select(p => p.Id).ToHashSet();

                var produtosParaRemover = comanda.ComandasProdutos
                    .Where(cp => !idsEnviados.Contains(cp.ProdutoId))
                    .ToList();

                _context.ComandasProdutos.RemoveRange(produtosParaRemover);

                foreach (var produtoReq in request.Produtos)
                {
                    var produto = await _context.Produtos.FindAsync(produtoReq.Id);

                    if (produto is null)
                    {
                        produto = new Produto
                        {
                            Nome = produtoReq.Nome,
                            Preco = produtoReq.Preco
                        };
                        _context.Produtos.Add(produto);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        produto.Nome = produtoReq.Nome;
                        produto.Preco = produtoReq.Preco;
                        _context.Produtos.Update(produto);
                    }

                    var existe = comanda.ComandasProdutos.Any(cp => cp.ProdutoId == produto.Id);

                    if (!existe)
                    {
                        var novaRelacao = new ComandaProduto
                        {
                            ComandaId = comanda.Id,
                            ProdutoId = produto.Id
                        };

                        _context.ComandasProdutos.Add(novaRelacao);
                    }
                }
            }

            await _context.SaveChangesAsync();

            var comandaAtualizada = await _context.Comandas
                .Include(c => c.ComandasProdutos)
                    .ThenInclude(cp => cp.Produto)
                .FirstOrDefaultAsync(c => c.Id == comanda.Id);

            return new ComandaResponse
            {
                Id = comandaAtualizada!.Id,
                IdUsuario = comandaAtualizada.IdUsuario,
                NomeUsuario = comandaAtualizada.NomeUsuario,
                TelefoneUsuario = comandaAtualizada.TelefoneUsuario,
                Produtos = comandaAtualizada.ComandasProdutos.Select(cp => new ProdutoResponse
                {
                    Id = cp.Produto.Id,
                    Nome = cp.Produto.Nome,
                    Preco = cp.Produto.Preco
                }).ToList()
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var comanda = await _context.Comandas
                .Include(c => c.ComandasProdutos)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comanda == null)
                return false;

            _context.ComandasProdutos.RemoveRange(comanda.ComandasProdutos);

            _context.Comandas.Remove(comanda);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
