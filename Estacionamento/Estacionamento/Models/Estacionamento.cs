using System;

namespace Estacionamento.Models
{
    public class Estacionamento
    {
        public int Registro { get; set; }
        public string ModeloVeiculo { get; set; }
        public string PlacaVeiculo { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public string Observacao { get; set; }                  
    }
}
