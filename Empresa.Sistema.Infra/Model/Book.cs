using Empresa.Sistema.Infra.Model.Base;
using RAG.Treinamentos.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Sistema.Infra.Model
{
    [Table("books")]
    public class Book : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Author")]
        public string Author { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }

        [Column("LaunchDate")]
        public DateTime LaunchDate { get; set; }
    }
}
