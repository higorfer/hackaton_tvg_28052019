using Empresa.Sistema.Domain.Business.Interfaces;
using Empresa.Sistema.Domain.Data.VO;
using Microsoft.AspNetCore.Mvc;
using RAG.Treinamentos.Api.Model;
using RAG.Treinamentos.Domain.Model;
using RAG.Treinamentos.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;


using System.Linq;

namespace Empresa.Sistema.Api.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/Cursos/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Curso]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CursosController : Controller
    {
        //Declaração do serviço usado
        private ICursoBusinessLogic _CursoBusiness;
        private IMatriculaBusinessLogic matriculaBusinessLogic;

        /* Injeção de uma instancia de ICursoBusiness ao criar
        uma instancia de CursoController */
        public CursosController(ICursoBusinessLogic cursoBusiness,
                                IMatriculaBusinessLogic matriculaBusinessLogic)
        {
            this._CursoBusiness = cursoBusiness;
            this.matriculaBusinessLogic = matriculaBusinessLogic;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Cursos/v1/
        // [SwaggerResponse((202), Type = typeof(List<Curso>))]
        // determina o objeto de retorno em caso de sucesso List<Curso>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<CursoModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Get()
        {

            //return new OkObjectResult(EntitiesToModels(_CursoBusiness.FindAll()));
            return new OkObjectResult(_CursoBusiness.FindAll());
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Cursos/v1/
        // [SwaggerResponse((202), Type = typeof(List<Curso>))]
        // determina o objeto de retorno em caso de sucesso List<Curso>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-by-name")]
        [SwaggerResponse((200), Type = typeof(List<CursoModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult GetByName([FromQuery] string firstName)
        {
            var result = new ResponseModel() {
                Data = _CursoBusiness.FindByName(firstName)
            };

            return new OkObjectResult(result);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Cursos/v1/
        // [SwaggerResponse((202), Type = typeof(List<Curso>))]
        // determina o objeto de retorno em caso de sucesso List<Curso>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-with-paged-search/{name}/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<CursoModel>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_CursoBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Cursos/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Curso))]
        // determina o objeto de retorno em caso de sucesso Curso
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(CursoModel))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Get(string id)
        {
            var result = new ResponseModel();

            var curso = _CursoBusiness.FindById(id);

            if (curso == null)
                return NotFound(result);
            //return new OkObjectResult(EntityToModel(Curso));

            result.Data = curso;

            return new OkObjectResult(result);
        }


        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(Curso))]
        // determina o objeto de retorno em caso de sucesso Curso
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(CursoModel))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Post([FromBody]CursoModel curso)
        {
            var result = new ResponseModel();

            if (curso == null)
                return BadRequest(result);

            result.Data = _CursoBusiness.Create(ModelToEntity(curso));

            return new OkObjectResult(result);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Cursos/v1/
        // determina o objeto de retorno em caso de sucesso Curso
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(CursoModel))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Put([FromBody]CursoModel curso)
        {
            var result = new ResponseModel();

            if (curso == null)
                return BadRequest(result);

            var updatedCurso = _CursoBusiness.Update(ModelToEntity(curso));

            if (updatedCurso == null)
                return BadRequest(result);

            result.Data = updatedCurso;

            return new OkObjectResult(result);
        }




        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Cursos/v1/{id}
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Delete(string id)
        {
            _CursoBusiness.Delete(id);
            // return NoContent();
            return Ok(new ResponseModel());

        }



        private Curso ModelToEntity(CursoModel cursoModel)
        {
            return new Curso()
            {
                Id = cursoModel.Id,
                Capacidade = cursoModel.Capacidade,
                CargaHoraria = cursoModel.CargaHoraria,
                DataInicio = cursoModel.DataInicio,
                Nome = cursoModel.Nome,
                Modalidade = cursoModel.Modalidade
            };
        }



        //private List<CursoModel> EntitiesToModels(List<Curso> cursos)
        //{
        //    List<CursoModel> list = new List<CursoModel>();

        //    foreach (var curso in cursos)
        //    {
        //        list.Add(EntityToModel(curso));
        //    }

        //    return list;
        //}



        [HttpGet("{id}/alunos")]
        [SwaggerResponse((200), Type = typeof(List<Aluno>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        public IActionResult AlunosPorCurso([FromRoute]string id, DateTime? dataInicial, DateTime? dataFinal )
        {
            var resut = this._CursoBusiness.AlunosPorCurso(id, dataInicial, dataFinal);

            if (resut == null)
                return NotFound();

            return new OkObjectResult(resut);
        }





        //[HttpGet("/totais")]
        //[SwaggerResponse((200), Type = typeof(List<Curso>))]
        //[SwaggerResponse(204)]
        //[SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        ////[Authorize("Bearer")]
        //public IActionResult Totais()
        //{       

        //    //if (resut == null) return NotFound();
        //    return new OkObjectResult(null);
        //}
    }
}