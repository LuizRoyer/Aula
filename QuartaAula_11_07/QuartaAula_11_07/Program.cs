using QuartaAula_11_07.Model;
using System;

namespace QuartaAula_11_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa p = new Pessoa("Luiz", 24);
            PessoaFisica pF = new PessoaFisica("AA",33 ,"09122199");
           


            Console.WriteLine(p.Nome);
            Console.WriteLine(pF.Nome);
            Console.ReadLine();

        }
    }
}
