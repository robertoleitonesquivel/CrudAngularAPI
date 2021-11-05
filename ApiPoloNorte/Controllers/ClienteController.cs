using ApiPoloNorte.IService;
using ApiPoloNorte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiPoloNorte.Controllers
{
    public class ClienteController : ApiController
    {
        public readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("api/Cliente/GetAllClientes")]
        public async Task<HttpResponseMessage> GetAllClientes()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _clienteService.GetAllClientes());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/Cliente/InsertClientes")]
        public async Task<HttpResponseMessage> InsertClientes(ClientesModel clientesModel)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _clienteService.InsertClientes(clientesModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Cliente/UpdateClientes")]
        public async Task<HttpResponseMessage> UpdateClientes(ClientesModel clientesModel)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _clienteService.UpdateClientes(clientesModel));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("api/Cliente/DeleteClientes/{cedula}")]
        public async Task<HttpResponseMessage> DeleteClientes(string cedula)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, await _clienteService.DeleteClientes(cedula));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
