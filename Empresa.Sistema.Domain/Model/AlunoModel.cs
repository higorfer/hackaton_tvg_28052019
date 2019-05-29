using RAG.Treinamentos.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAG.Treinamentos.Domain.Model
{
    public class AlunoModel : BaseModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

    }

}
