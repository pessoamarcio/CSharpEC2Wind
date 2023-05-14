using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFromLuiz.Models;
using ProjetoFromLuiz.Repository;
using ProjetoFromLuiz.Repository.Interfaces;
using ProjetoFromLuiz.Util;

namespace ProjetoFromLuiz.Controllers
{

    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        public static PessoaUtil _pessoaUtil;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
            List<PessoaModel> pessoas = _pessoaRepository.ListarTodos().Result;
            _pessoaUtil = new PessoaUtil(pessoas);
        }

        [HttpGet]
        [Route("api/pessoas")]
        public async Task<ActionResult<List<PessoaModel>>> ListarTodasPessoas()
        {
            List<PessoaModel> pessoas = await _pessoaRepository.ListarTodos();
            return Ok(pessoas);
        }

        [HttpGet]
        [Route("api/pessoas/{id}")]
        public async Task<ActionResult<PessoaModel>> ListarPessoasId(int id)
        {
            PessoaModel pessoa = await _pessoaRepository.ListarPessoaPorId(id);

            return Ok(pessoa);
        }

        [HttpPost]
        [Route("api/pessoas")]
        public async Task<ActionResult<PessoaModel>> AdicionarPessoa([FromBody] PessoaModel novaPessoa)
        {
            PessoaModel pessoa = await _pessoaRepository.AdicionarPessoa(novaPessoa);

            return Ok(pessoa);
        }

        [HttpPut]
        [Route("api/pessoas/{id}")]
        public async Task<ActionResult<PessoaModel>> AtualizarPessoas([FromBody] PessoaModel PessoaAtualizada, int id)
        {

            PessoaModel pessoa = await _pessoaRepository.AtualizacaoDaPessoa(PessoaAtualizada, id);

            return Ok(pessoa);
        }

        [HttpDelete]
        [Route("api/pessoas/{id}")]
        public async Task<ActionResult<PessoaModel>> ExcluirPessoa(int id)
        {
            bool pessoa = await _pessoaRepository.ExcluirPessoa(id);

            return Ok(pessoa);
        }

        [HttpGet]
        [Route("api/pessoas/imc/{id}")]
        public async Task<ActionResult<List<PessoaModel>>> CalcularIMC(int id)
        {
            var pessoa = await _pessoaRepository.ListarPessoaPorId(id);
            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada!");
            }

            var imc = pessoa.IMC;
            var nome = pessoa.Nome;
            var dadosPessoa = new { nome, IMC = imc };
            return Ok(dadosPessoa);
        }

        [HttpGet]
        [Route("api/pessoas/filtro-media-idade")]
        public async Task<ActionResult<double>> FiltrarPessoaPorMediaIdade()
        {
            var pessoas = await _pessoaRepository.ListarTodos();
            var media = Math.Round(pessoas.Average(p => p.Idade), 2);

            return Ok(media);
        }

        [HttpGet]
        [Route("api/pessoas/pessoas-com-letra-l")]
        public async Task<ActionResult<double>> ContarPessoasComLetraL()
        {
            var count = await _pessoaRepository.ContarPessoasComLetraL();
            return Ok(count);
        }

        [HttpGet]
        [Route("api/pessoas/filtro-peso/{min}/{max}")]
        public async Task<ActionResult> FiltrarPessoaPorPeso(double min, double max)
        {
            var filtrarPorPeso = await _pessoaRepository.FiltrarPessoasPorPeso(min, max);
            return Ok(filtrarPorPeso);
        }

        [HttpGet]
        [Route("api/pessoas/nivel-saude")]
        public async Task<ActionResult> ListarPessoasComNivelDeSaude()
        {
            var pessoas = await _pessoaRepository.ListarTodos();
            var pessoasComNivelDeSaude = _pessoaUtil.ListarPessoasComNivelDeSaude(pessoas);
            return Ok(pessoasComNivelDeSaude);
        }

    }
}
