using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RAG.Treinamentos.Model
{

    [Table("Aluno")]
    public class Aluno : BaseEntity
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("sobrenome")]
        public string Sobrenome { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonIgnore]
        public ICollection<Matricula> Matriculas { get; set; }

        //[NotMapped]
        //[JsonProperty("dataMatricula")]
        //public DateTime DataMatricula { get; set; }

    }



}



