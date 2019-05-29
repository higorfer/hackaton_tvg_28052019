using RAG.Treinamentos.Model.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAG.Treinamentos.Domain.Model
{
    public class CursoModel : BaseModel
    {

        public string Nome { get; set; }

        public int CargaHoraria { get; set; }        

        public TipoCurso Modalidade { get; set; }

        public int Capacidade { get; set; }

        public DateTime DataInicio { get; set; }
    }
}
