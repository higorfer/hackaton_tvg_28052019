using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RAG.Treinamentos.Model
{
    public abstract class BaseEntity
    {
        [JsonProperty("id")]
        [Column("id")]
        public string Id { get; set; }
    }
}
