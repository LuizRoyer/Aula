namespace QuartaAula_11_07.Model
{
    public class Pessoa
    {
        public Pessoa(string nome , int idade)
        {
            this.Idade = idade;
            this.Nome = nome;
        }
        public string Nome { get;  set; }
        public int Idade { get; set; }

    }
}
