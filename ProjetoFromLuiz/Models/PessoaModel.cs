namespace ProjetoFromLuiz.Models
{
    public class PessoaModel
    {

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public string? Email { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public string NivelDeSaude;

        public double IMC
        {
            get
            {
                return Math.Round(Peso / (Altura * Altura), 2);
            }
        }
       
    }

}
