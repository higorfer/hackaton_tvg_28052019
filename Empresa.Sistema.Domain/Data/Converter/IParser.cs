using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Domain.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
