using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Dynamic;
using biblioteca_rest_service.Dal;
using biblioteca_rest_service.Models;
using biblioteca_rest_service.Dtos;
using AutoMapper;
using biblioteca_rest_service.Constants;

namespace biblioteca_rest_service.Controllers
{
    public class CatalogoController : ApiController
    {
        dynamic response = null;
        CatalogoRepository repository;
        CatalogoController()
        {
            repository = new CatalogoRepository();
            response = new ExpandoObject();
        }

        [Route("catalogos")]
        [HttpGet]
        public IHttpActionResult getAll(string name = "none")
        {
            try
            {
                List<t_catalogo> catalogo = new List<t_catalogo>();
                if (name.Equals("none"))
                {
                    catalogo = repository.GetAll().ToList();
                }
                else
                {
                    catalogo = repository.FindBy(x => x.tx_descripcion == name).ToList();
                }
                //var catalogo = repository.GetAll();
                List<Catalogo> catalogoDto = catalogo.Select(Mapper.Map<t_catalogo, Catalogo>).ToList();
                response = catalogoDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = Constants.ResponseStatus.error;
                response.Message = Constants.ErrorMessage.internal_server_error;
                return Content(HttpStatusCode.InternalServerError,response);
            }
        }

        [Route("catalogos/{id:int}")]
        [HttpGet]
        public IHttpActionResult getSingle(int id)
        {
            try
            {
                t_catalogo catalogo = repository.GetSingle(id);
                Catalogo catalogoDto = Mapper.Map<t_catalogo, Catalogo>(catalogo);
                response = catalogoDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = Constants.ResponseStatus.error;
                response.Message = Constants.ErrorMessage.internal_server_error;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("catalogos")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] Catalogo catalogoDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    response.Status = Constants.ResponseStatus.error;
                    response.Code = HttpStatusCode.BadRequest;
                    response.Message = Constants.ErrorMessage.bad_request;
                    return Content(HttpStatusCode.BadRequest, response);
                }
                else
                {
                    t_catalogo catalogo = Mapper.Map<Catalogo, t_catalogo>(catalogoDto);
                    repository.Add(catalogo);
                    repository.Save();
                    catalogoDto.id_articulo = catalogo.id_articulo;
                    return Created(new Uri($"{Request.RequestUri}/{catalogoDto.id_articulo}"), catalogoDto);
                }
            }
            catch (Exception ex)
            {
                response.Status = Constants.ResponseStatus.error;
                response.Message = Constants.ErrorMessage.internal_server_error;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }
    }
}
