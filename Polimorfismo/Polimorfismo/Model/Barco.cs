using System;

namespace Polimorfismo.Model
{
   public  class Barco:Veiculo
    {
        public Barco(string tipo) : base(tipo) { }

        public override void Mover()
        {
            Console.WriteLine("Barco Esta se movendo");
        }
        public override void Parar()
        {
            Console.WriteLine("Barco Parou");
        }
    }
}
