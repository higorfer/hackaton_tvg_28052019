using Empresa.Sistema.Domain.Data.Converter;
using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using System.Collections.Generic;
using System.Linq;

namespace Empresa.Sistema.Domain.Data.Converters
{
    public class PersonConverter : IParser<VO.Person, Infra.Model.Person>, IParser<Infra.Model.Person, VO.Person>
    {
        public Person Parse(VO.Person origin)
        {
            if (origin == null) return new Infra.Model.Person();
            return new Infra.Model.Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                //LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public Person Parse(Infra.Model.Person origin)
        {
            if (origin == null) return new VO.Person();
            return new VO.Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                //LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Infra.Model.Person> ParseList(List<VO.Person> origin)
        {
            if (origin == null) return new List<Infra.Model.Person>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<VO.Person> ParseList(List<Infra.Model.Person> origin)
        {
            if (origin == null) return new List<VO.Person>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
