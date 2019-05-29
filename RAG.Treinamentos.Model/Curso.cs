using Newtonsoft.Json;
using RAG.Treinamentos.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RAG.Treinamentos.Model
{

    [Table("Curso")]
    public class Curso : BaseEntity
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("cargaHoraria")]
        public int CargaHoraria { get; set; }

        [JsonIgnore]
        public ICollection<Matricula> Matriculas { get; set; }

        [JsonProperty("modalidade")]
        public TipoCurso Modalidade { get; set; }

        [JsonProperty("capacidade")]
        public int Capacidade { get; set; }


        [JsonProperty("dataInicio")]
        public DateTime DataInicio { get; set; }

    }

}
