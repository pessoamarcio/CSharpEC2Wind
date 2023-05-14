using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFromLuiz.Data;
using ProjetoFromLuiz.Models;
using ProjetoFromLuiz.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using ProjetoFromLuiz.Util;

namespace ProjetoFromLuiz.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly SistemaPessoaDBContex _dbContext;
        private readonly PessoaUtil _pessoaUtil;

        public PessoaRepository(SistemaPessoaDBContex sistemaPessoaDBContex)
        {
            _dbContext = sistemaPessoaDBContex;
            _pessoaUtil = new PessoaUtil(new List<PessoaModel>());
        }

        public async Task<PessoaModel> ListarPessoaPorId(int id)
        {
            return await _dbContext.PessoaSistema.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<PessoaModel>> ListarTodos()
        {
            return await _dbContext.PessoaSistema.ToListAsync();
        }

        public async Task<PessoaModel> AdicionarPessoa(PessoaModel pessoa)
        {
            await _dbContext.PessoaSistema.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }

        public async Task<PessoaModel> AtualizacaoDaPessoa(PessoaModel atualizacaoDaPessoa, int id)
        {
            PessoaModel pessoaId = await ListarPessoaPorId(id);

            if (pessoaId == null)
            {
                throw new Exception("Não localizado!");
            }

            pessoaId.Nome = atualizacaoDaPessoa.Nome;
            pessoaId.Idade = atualizacaoDaPessoa.Idade;
            pessoaId.Email = atualizacaoDaPessoa.Email;
            pessoaId.Peso = atualizacaoDaPessoa.Peso;
            pessoaId.Altura = atualizacaoDaPessoa.Altura;

            _dbContext.PessoaSistema.Update(pessoaId);
            await _dbContext.SaveChangesAsync();
            return pessoaId;
        }

        public async Task<bool> ExcluirPessoa(int id)
        {
            PessoaModel pessoaId = await ListarPessoaPorId(id);

            if (pessoaId == null)
            {
                throw new Exception("Não localizado!");
            }

            _dbContext.PessoaSistema.Remove(pessoaId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<PessoaModel> CalcularIMC(int id)
        {
            PessoaModel pessoaIMC = await _dbContext.PessoaSistema.FirstOrDefaultAsync(p => p.Id == id);

            if (pessoaIMC == null)
            {
                throw new Exception("Pessoa não encontrada ou não cadastrada!");
            }

            return pessoaIMC;
        }

        public async Task<double> FiltrarPessoaPorMediaIdade()
        {
            var idades = await _dbContext.PessoaSistema.Select(p => p.Idade).ToListAsync();
            var media = idades.Average();

            return Math.Round(media, 2);
        }

        public async Task<double> ContarPessoasComLetraL()
        {
            var pessoasComLetraL = await _dbContext.PessoaSistema.Where(p => p.Nome.ToLower()
                .Contains("l")).CountAsync();
            return pessoasComLetraL;
        }

        public async Task<List<PessoaModel>> FiltrarPessoasPorPeso(double min, double max)
        {
            var filtrarPorPeso = await _dbContext.PessoaSistema.Where(p => p.Peso >= min && 
                p.Peso <= max).ToListAsync();

            return filtrarPorPeso;
        }
    }
}
