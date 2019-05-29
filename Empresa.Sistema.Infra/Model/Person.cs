using Empresa.Sistema.Infra.Model.Base;
using RAG.Treinamentos.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Sistema.Infra.Model
{
    [Table("persons")]
    public class Person : BaseEntity
    {
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Column("LastName")]
        public string LastName { get; set; }

        [Column("Address")]
        public string Address { get; set; }

        [Column("Gender")]
        public string Gender { get; set; }
    }
}
