using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RAG.Treinamentos.Model
{
    [Table("Matricula")]
    public class Matricula : BaseEntity
    {
        [JsonProperty("idCurso")]
        public string IdCurso { get; set; }

        [JsonProperty("idAluno")]
        public string IdAluno { get; set; }

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonIgnore]
        public Aluno Aluno { get; set; }

        [JsonIgnore]
        public Curso Curso { get; set; }
    }
}
