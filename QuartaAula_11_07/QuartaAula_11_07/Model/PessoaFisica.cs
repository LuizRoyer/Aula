
namespace QuartaAula_11_07.Model
{
    public class PessoaFisica:Pessoa
    {
        public PessoaFisica(string nome, int idade, string cpf) : base(nome, idade) { this.CPF = cpf; }

        public string CPF { get; set; }
    }
}
