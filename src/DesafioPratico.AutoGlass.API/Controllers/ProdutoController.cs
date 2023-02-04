using AutoMapper;
using DesafioPratico.AutoGlass.API.DTOs;
using DesafioPratico.AutoGlass.Domain.Enums;
using DesafioPratico.AutoGlass.Domain.Interfaces.Notificacoes;
using DesafioPratico.AutoGlass.Domain.Interfaces.Repository;
using DesafioPratico.AutoGlass.Domain.Interfaces.Services;
using DesafioPratico.AutoGlass.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPratico.AutoGlass.API.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController: MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository produtoRepository, IProdutoService produtoService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet("obter-por-id/{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(int id)
        {
            var fornecedor = _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));

            if (fornecedor == null) return NotFound();

            return Ok(fornecedor);
        }

        [HttpGet("obter-todos")]
        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            var produto = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos());
            return produto;
        }

        [HttpGet("obter-por-situacao/{situacao:int}")]
        public async Task<IEnumerable<ProdutoDTO>> ObterPorSituacao(int situacao)
        {
            var produto = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosPorSituacao((SituacaoProduto)situacao));
            return produto;
        }

        [HttpGet("obter-produtos-vencidos")]
        public async Task<IEnumerable<ProdutoDTO>> ObterProdutosVencidos()
        {
            var produto = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosVencidos());
            return produto;
        }

        [HttpGet("obter-produtos-por-fornecedor/{idFornecedor:int}")]
        public async Task<IEnumerable<ProdutoDTO>> ObterProdutosFornecedor(int idFornecedor)
        {
            var produto = _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosPorFornecedor(idFornecedor));
            return produto;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDTO));

            return CustomResponse(produtoDTO);
        }

        [HttpPut("atualizar/{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> Atualizar(int id, ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(produtoDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoDTO));

            return CustomResponse(produtoDTO);
        }

        [HttpPost("excluir/{id:int}")]
        public async Task<ActionResult<ProdutoDTO>> InativarProduto(int id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _produtoService.InativarProduto(id);

            return CustomResponse(result);
        }
    }
}
