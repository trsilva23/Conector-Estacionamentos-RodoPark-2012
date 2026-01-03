using System;

namespace ParkConnect.Models
{
    public class Condomino
    {
        public int IdCondomino { get; set; }
        public string Nome { get; set; }
        public string PlacaVeiculo { get; set; }
        public string Unidade { get; set; }
        public bool EstaAdimplente { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
    }
}
