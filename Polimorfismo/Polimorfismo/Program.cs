using Polimorfismo.Model;
using System;

namespace Polimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Veiculo[] ListVeiculo = new Veiculo[2];
            ListVeiculo[0] = new Carro("Ferrari");
            ListVeiculo[1] = new Barco("Batera");

            for (int i = 0; i < ListVeiculo.Length; i++)
            {
                Movendo(ListVeiculo[i]);
                Pararando(ListVeiculo[i]);
            }
            

            Console.ReadKey();
        }
        static void Movendo(Veiculo veiculo)
        {
            Console.WriteLine("Tipo Veiculo " + veiculo.Tipo);
                veiculo.Mover();
        }
        static void Pararando(Veiculo veiculo)
        {
            Console.WriteLine("Tipo Veiculo " + veiculo.Tipo);
            veiculo.Parar();
        }
    }
}
