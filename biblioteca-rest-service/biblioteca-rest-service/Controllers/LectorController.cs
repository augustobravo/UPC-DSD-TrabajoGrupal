using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using biblioteca_rest_service.Dal;
using biblioteca_rest_service.Models;
using biblioteca_rest_service.Dtos;
using System.Dynamic;
using AutoMapper;


namespace biblioteca_rest_service.Controllers
{
    public class LectorController : ApiController
    {

        dynamic response = null;
        LectorRepository repository;

        public LectorController()
        {
            repository = new LectorRepository();
            response = new ExpandoObject();
        }

        [Route("authenticate")]
        [HttpPost]
        public IHttpActionResult authenticate(Login user)
        {
            try
            {
                t_lector lector = repository.FindBy(x => x.tx_email == user.email && x.tx_contrasena == user.contrasena).FirstOrDefault();
                if (lector != null)
                {
                    response = lector;
                    return Ok(response);
                }
                else
                {
                    return Content(HttpStatusCode.Unauthorized, HttpStatusCode.Unauthorized);
                }
            }
            catch (Exception ex)
            {
                response.Status = Constants.ResponseStatus.error;
                response.Message = Constants.ErrorMessage.internal_server_error;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("lectores")]
        [HttpGet]
        public IHttpActionResult getAll()
        {
            try
            {
                List<t_lector> lectores = new List<t_lector>();
                lectores = repository.GetAll().ToList();               
                //var catalogo = repository.GetAll();
                List<Lector> lectoresDto = lectores.Select(Mapper.Map<t_lector, Lector>).ToList();
                response = lectoresDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = Constants.ResponseStatus.error;
                response.Message = Constants.ErrorMessage.internal_server_error;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("lectores/{id:int}")]
        [HttpGet]
        public IHttpActionResult getSingle(int id)
        {
            try
            {
                t_lector lector = repository.GetSingle(id);
                Lector lectorDto = Mapper.Map<t_lector, Lector>(lector);
                response = lectorDto;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = Constants.ResponseStatus.error;
                response.Message = Constants.ErrorMessage.internal_server_error;
                return Content(HttpStatusCode.InternalServerError, response);
            }
        }

        [Route("lectores")]
        [HttpPost]
        public IHttpActionResult Add([FromBody] Lector lectorDto)
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
                    t_lector lector = Mapper.Map<Lector, t_lector>(lectorDto);
                    repository.Add(lector);
                    repository.Save();
                    lectorDto.id_lector = lector.id_lector;
                    return Created(new Uri($"{Request.RequestUri}/{lectorDto.id_lector}"), lectorDto);
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
