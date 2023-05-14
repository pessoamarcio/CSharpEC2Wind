using ProjetoFromLuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoFromLuiz.Util
    {
    public class PessoaUtil

    {
        private readonly List<PessoaModel> _pessoas;

        public PessoaUtil(List<PessoaModel> pessoas)
        {
            _pessoas = pessoas;
        }

        public double MediaIdade()
        {
            return _pessoas.Average(p => p.Idade);
        }

        public int ContarLetraL()
        {
            return _pessoas.Count(p => p.Nome.ToLower().Contains("l"));
        }

        public List<PessoaModel> FiltrarPorPeso(double min, double max)
        {
            return _pessoas.Where(p => p.Peso >= min && p.Peso <= max).ToList();
        }

        public List<object> ListarPessoasComNivelDeSaude(List<PessoaModel> pessoas)
        {
            var pessoasComNivelDeSaude = new List<object>();
            foreach (var pessoa in pessoas)
            {
                var nivelDeSaude = "";
                if (pessoa.IMC < 18.5)
                {
                    nivelDeSaude = "Abaixo do peso";
                }
                else if (pessoa.IMC >= 18.5 && pessoa.IMC <= 24.9)
                {
                    nivelDeSaude = "Peso normal";
                }
                else if (pessoa.IMC >= 25 && pessoa.IMC <= 29.9)
                {
                    nivelDeSaude = "Sobrepeso";
                }
                else if (pessoa.IMC >= 30 && pessoa.IMC <= 34.9)
                {
                    nivelDeSaude = "Obesidade grau 1";
                }
                else if (pessoa.IMC >= 35 && pessoa.IMC <= 39.9)
                {
                    nivelDeSaude = "Obesidade grau 2";
                }
                else if (pessoa.IMC >= 40)
                {
                    nivelDeSaude = "Obesidade grau 3";
                }
                pessoasComNivelDeSaude.Add(new { Pessoa = pessoa, NivelDeSaude = nivelDeSaude });
            }
            return pessoasComNivelDeSaude;
        }


    }

}

