namespace Polimorfismo.Model
{
    public class Veiculo
    {
        public string Tipo { get; set; }

        public Veiculo(string tipo)
        {
            this.Tipo = tipo;
        }

        public virtual void Mover() { }
        public virtual void Parar() { }
    }
}
