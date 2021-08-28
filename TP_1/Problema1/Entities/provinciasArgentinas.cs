using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TP1_2021.Entities
{
    public class Parametro
    {
        [JsonPropertyName("campos")]
        public List<string> Campos { get; set; }
    }
    public class provincia
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("nombre")]
        public string Nombre { get; set; }
    }
    public class provinciasArgentina
    {
        [JsonPropertyName("cantidad")]
        public int Cantidad { get; set; }
        [JsonPropertyName("inicio")]
        public int Inicio { get; set; }
        [JsonPropertyName("parametro")]
        public Parametro Parametro { get; set; }
        [JsonPropertyName("provincias")]
        public List<provincia> Provincias { get; set; }
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}