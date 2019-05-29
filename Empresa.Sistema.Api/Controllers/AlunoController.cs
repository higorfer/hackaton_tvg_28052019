using Empresa.Sistema.Domain.Business.Interfaces;
using Empresa.Sistema.Domain.Data.VO;
using Microsoft.AspNetCore.Mvc;
using RAG.Treinamentos.Api.Model;
using RAG.Treinamentos.Domain.Model;
using RAG.Treinamentos.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;

namespace Empresa.Sistema.Api.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/Alunos/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Aluno]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AlunoController : Controller
    {
        //Declaração do serviço usado
        private IAlunoBusinessLogic _AlunoBusiness;
        private IMatriculaBusinessLogic matriculaBusinessLogic;

        /* Injeção de uma instancia de IAlunoBusiness ao criar
        uma instancia de AlunoController */
        public AlunoController(IAlunoBusinessLogic alunoBusiness, IMatriculaBusinessLogic matriculaBusinessLogic)
        {
            this._AlunoBusiness = alunoBusiness;
            this.matriculaBusinessLogic = matriculaBusinessLogic;
        }


        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<Aluno>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Get()
        {

            var result = new ResponseModel()
            {
                Data = _AlunoBusiness.FindAll()
            };

            return new OkObjectResult(result);
        }


        [HttpGet("find-by-name")]
        [SwaggerResponse((200), Type = typeof(List<Aluno>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult GetByName([FromQuery] string firstName, string lastName)
        {
            return new OkObjectResult(_AlunoBusiness.FindByName(firstName, lastName));
        }

        [HttpGet("find-with-paged-search/{name}/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<Aluno>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_AlunoBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }


        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(Aluno))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Get(string id)
        {

            var aluno = _AlunoBusiness.FindById(id);

            if (aluno == null)
                return NotFound(new ResponseModel());

            var result = new ResponseModel()
            {
                Data = aluno
            };

            return new OkObjectResult(result);
        }

        [HttpPost]
        [SwaggerResponse((201), Type = typeof(Aluno))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Post([FromBody]Aluno Aluno)
        {
            var result = new ResponseModel();

            if (Aluno == null)
                return BadRequest(result);

            result.Data = _AlunoBusiness.Create(Aluno);

            return new OkObjectResult(result);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Alunos/v1/
        // determina o objeto de retorno em caso de sucesso Aluno
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPut]
        [SwaggerResponse((202), Type = typeof(Aluno))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Put([FromBody]Aluno Aluno)
        {
            var result = new ResponseModel()
            {

            };

            if (Aluno == null)
                return BadRequest(result);

            var updatedAluno = _AlunoBusiness.Update(Aluno);

            if (updatedAluno == null)
                return BadRequest(result);

            result.Data = updatedAluno;

            return new OkObjectResult(result);
        }



        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Alunos/v1/{id}
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpDelete("{id}")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Delete(string id)
        {
            _AlunoBusiness.Delete(id);

            var result = new ResponseModel()
            {

            };

            return Ok(result);

            //return NoContent();
        }

        private Aluno ModelToEntity(AlunoModel alunoModel)
        {
            return new Aluno()
            {
                Id = alunoModel.Id,
                CPF = alunoModel.CPF,
                DataNascimento = alunoModel.DataNascimento,
                Nome = alunoModel.Nome,
                Sobrenome = alunoModel.Sobrenome,
            };
        }

        [HttpGet("{id}/cursos")]
        [SwaggerResponse((200), Type = typeof(List<Curso>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]
        public IActionResult CursosPorAluno([FromRoute]string id, DateTime? dataInicial, DateTime? dataFinal)
        {
            var resut = this._AlunoBusiness.CursosPorAluno(id, dataInicial, dataFinal);

            if (resut == null)
                return NotFound();

            return new OkObjectResult(resut);
        }


    }
}