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
    public class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {

        public CursoRepository(MySQLContext context) : base(context) { }

        public List<Curso> FindByName(string firstName)
        {
            if (!string.IsNullOrEmpty(firstName))
            {
                return _context.Cursos.Where(p => p.Nome.Contains(firstName)).ToList();
            }
            return _context.Cursos.ToList();
        }

        public List<AlunoCurso> AlunosPorCurso(string id, DateTime? dataInicial, DateTime? dataFinal)
        {
            var dInicial = dataInicial.HasValue ? dataInicial.Value : DateTime.MinValue;
            var dFinal = dataFinal.HasValue ? dataFinal.Value : DateTime.MaxValue;

            //string query = $@"SELECT ALU.*, MAT.Data as DataMatricula FROM ALUNO ALU
            //                INNER JOIN MATRICULA MAT ON MAT.IdAluno = ALU.Id
            //                WHERE MAT.IdCurso = {id}
            //                AND MAT.DATA BETWEEN('{dInicial.ToString("yyyy/MM/dd")}') AND ('{dFinal.ToString("yyyy/MM/dd")}')";


            //return _context.Alunos.FromSql<Aluno>(query).ToList();   

            var result = this._context.Matriculas
                        .Include(m => m.Aluno)
                        .Include(m => m.Curso)
                        .Where(m => m.IdCurso == id && m.Data >= dInicial.Date && m.Data <= dFinal.Date)
                        .Select(s => new AlunoCurso()
                        {
                            Id = s.Aluno.Id,
                            CPF = s.Aluno.CPF,
                            DataNascimento = s.Aluno.DataNascimento,
                            Nome = s.Aluno.Nome,
                            Sobrenome = s.Aluno.Sobrenome,
                            DataMatricula = s.Data
                        }).ToList();


            return result;
        }


        //SELECT ALU.* FROM ALUNO ALU
        //INNER JOIN MATRICULA MAT ON MAT.IdAluno = ALU.Id
        //WHERE MAT.IdCurso = 7

        //    AND MAT.DATA BETWEEN STR_TO_DATE('2019/05/28', 'YYYY/mm/DD') AND STR_TO_DATE('2019/05/28', 'YYYY/mm/DD');


    }
}