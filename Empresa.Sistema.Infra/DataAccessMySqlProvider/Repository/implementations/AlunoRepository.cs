using Empresa.Sistema.Infra.DataAccessMySqlProvider.Context;
using Empresa.Sistema.Infra.DataAccessMySqlProvider.Repository.Generic;
using Empresa.Sistema.Infra.Model;
using RAG.Treinamentos.Model;
using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

namespace Empresa.Sistema.Infra.Repository.implementations
{
    public class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
    {

        public AlunoRepository(MySQLContext context) : base(context) { }

        public List<Aluno> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Alunos.Where(p => p.Nome.Contains(firstName) && p.Sobrenome.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Alunos.Where(p => p.Sobrenome.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Alunos.Where(p => p.Nome.Contains(firstName)).ToList();
            }
            return _context.Alunos.ToList();
        }

        public List<Curso> CursosPorAluno(string id, DateTime? dataInicial, DateTime? dataFinal)
        {
            var dInicial = dataInicial.HasValue ? dataInicial.Value : DateTime.MinValue;
            var dFinal = dataFinal.HasValue ? dataFinal.Value : DateTime.MaxValue;

            string query = $@"SELECT CUR.* FROM CURSO CUR
                                INNER JOIN MATRICULA MAT ON MAT.IdCurso = Cur.Id 
                                WHERE MAT.IdAluno = {id}
                               AND MAT.DATA BETWEEN({dInicial.ToString("YYYY/mm/DD")}) AND ({dFinal.ToString("YYYY/mm/DD")})";


            return _context.Cursos.FromSql<Curso>(query).ToList();

            //var result = this._context.Matriculas
            //            .Include(m => m.Aluno)
            //            .Include(m => m.Curso)
            //            .Where(m => m.IdCurso == id && m.Data >= dInicial.Date && m.Data <= dFinal.Date)
            //            .Select(s => new AlunoCurso()
            //            {
            //                Id = s.Aluno.Id,
            //                CPF = s.Aluno.CPF,
            //                DataNascimento = s.Aluno.DataNascimento,
            //                Nome = s.Aluno.Nome,
            //                Sobrenome = s.Aluno.Sobrenome,
            //                DataMatricula = s.Data
            //            }).ToList();


            //return result;

        }



    }
}