using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace ApiMongo.Data.Collections
{
    public class Infectado
    {
        public Infectado(int id, string nome, DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.Id = id;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public int Id { get; set; }
        public string Nome { get; set; }     
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}