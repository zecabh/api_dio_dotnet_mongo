using System;

namespace ApiMongo.Models
{
    public class InfectadoDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}