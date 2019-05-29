using AutoMapper;
using Empresa.Sistema.Domain.Data.VO;
using Empresa.Sistema.Infra.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa.Sistema.Domain.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserVO>();
            CreateMap<Person, PersonVO>();
            CreateMap<Book, BookVO>();
         }
    }
}
