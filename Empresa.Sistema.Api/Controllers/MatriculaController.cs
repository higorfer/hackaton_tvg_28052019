using Empresa.Sistema.Domain.Business.Interfaces;
using Empresa.Sistema.Domain.Data.VO;
using Microsoft.AspNetCore.Mvc;
using RAG.Treinamentos.Api.Model;
using RAG.Treinamentos.Model;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Empresa.Sistema.Api.Controllers
{
    /* Mapeia as requisições de http://localhost:{porta}/api/Matricula/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Matricula]Controller
    e expõe como endpoint REST
    */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class MatriculaController : Controller
    {
        //Declaração do serviço usado
        private IMatriculaBusinessLogic _MatriculaBusiness;

        /* Injeção de uma instancia de IMatriculaBusiness ao criar
        uma instancia de MatriculaController */
        public MatriculaController(IMatriculaBusinessLogic MatriculaBusiness)
        {
            _MatriculaBusiness = MatriculaBusiness;
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Matricula/v1/
        // [SwaggerResponse((202), Type = typeof(List<Matricula>))]
        // determina o objeto de retorno em caso de sucesso List<Matricula>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet]
        [SwaggerResponse((200), Type = typeof(List<Matricula>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Get()
        {
            return new OkObjectResult(_MatriculaBusiness.FindAll());
        }


        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Matricula/v1/
        // [SwaggerResponse((202), Type = typeof(List<Matricula>))]
        // determina o objeto de retorno em caso de sucesso List<Matricula>
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("find-with-paged-search/{name}/{sortDirection}/{pageSize}/{page}")]
        [SwaggerResponse((200), Type = typeof(List<Matricula>))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult GetPagedSearch([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return new OkObjectResult(_MatriculaBusiness.FindWithPagedSearch(name, sortDirection, pageSize, page));
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/Matricula/v1/{id}
        // [SwaggerResponse((202), Type = typeof(Matricula))]
        // determina o objeto de retorno em caso de sucesso Matricula
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 204, 400 e 401
        [HttpGet("{id}")]
        [SwaggerResponse((200), Type = typeof(Matricula))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Get(string id)
        {
            var Matricula = _MatriculaBusiness.FindById(id);
            if (Matricula == null) return NotFound();
            return new OkObjectResult(Matricula);
        }

        // Configura o Swagger para a operação
        // http://localhost:{porta}/api/
        // [SwaggerResponse((202), Type = typeof(Matricula))]
        // determina o objeto de retorno em caso de sucesso Matricula
        // O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        [HttpPost]
        [SwaggerResponse((201), Type = typeof(Matricula))]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Post([FromBody]Matricula Matricula)
        {
            var result = new ResponseModel();

            if (Matricula == null)
                return BadRequest(result);

            result.Data = _MatriculaBusiness.Create(Matricula);

            return new OkObjectResult(result);
        }

        //// Configura o Swagger para a operação
        //// http://localhost:{porta}/api/Matricula/v1/
        //// determina o objeto de retorno em caso de sucesso Matricula
        //// O [SwaggerResponse(XYZ)] define os códigos de retorno 400 e 401
        //[HttpPut]
        //[SwaggerResponse((202), Type = typeof(Matricula))]
        //[SwaggerResponse(400)]
        //[SwaggerResponse(401)]
        ////[Authorize("Bearer")]

        //public IActionResult Put([FromBody]Matricula Matricula)
        //{
        //    if (Matricula == null) return BadRequest();
        //    var updatedMatricula = _MatriculaBusiness.Update(Matricula);
        //    if (updatedMatricula == null) return BadRequest();
        //    return new OkObjectResult(updatedMatricula);
        //}




        [HttpDelete]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        //[Authorize("Bearer")]

        public IActionResult Delete([FromBody]Matricula matricula)
        {
            var result = new ResponseModel();

            //var r = this._MatriculaBusiness.FindByAlunoId(matricula.IdAluno);
            //_MatriculaBusiness.Delete(id);
            //  return NoContent();
            return Ok(result);
        }
    }
}