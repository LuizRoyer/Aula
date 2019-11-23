using System;

namespace Polimorfismo.Model
{
    public class Carro:Veiculo
    {
        public Carro(string tipo) : base(tipo) { }

        public override void Mover()
        {
            Console.WriteLine("Acelarando o Carro");
        }
        public override void Parar()
        {
            Console.WriteLine("O carro Parou");
        }
    }
}
