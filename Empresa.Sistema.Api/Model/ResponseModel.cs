using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAG.Treinamentos.Api.Model
{
    public class ResponseModel
    {
        public List<int> ErrorsCode { get; set; } = new List<int>();
        public object Data = new object();
    }
}
