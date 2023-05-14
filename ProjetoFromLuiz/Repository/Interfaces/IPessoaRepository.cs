using ProjetoFromLuiz.Models;

namespace ProjetoFromLuiz.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        Task<PessoaModel> ListarPessoaPorId(int id);
        Task<List<PessoaModel>> ListarTodos();
        Task<PessoaModel> AdicionarPessoa(PessoaModel pessoa);
        Task<PessoaModel> AtualizacaoDaPessoa(PessoaModel pessoa, int id);
        Task<bool> ExcluirPessoa(int id);
        Task<PessoaModel> CalcularIMC(int id);
        Task<double> FiltrarPessoaPorMediaIdade();
        Task<double> ContarPessoasComLetraL();
        Task<List<PessoaModel>> FiltrarPessoasPorPeso(double min, double max);
    }
}
