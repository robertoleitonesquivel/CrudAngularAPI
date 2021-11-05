using ApiPoloNorte.IRepostory;
using ApiPoloNorte.IService;
using ApiPoloNorte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ApiPoloNorte.Service
{
    public class ClienteService : IClienteService
    {
        public readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task<string> DeleteClientes(string cedula)
        {
            return await this._clienteRepository.DeleteClientes(cedula);
        }

        public async Task<List<ClientesModel>> GetAllClientes()
        {
            return await this._clienteRepository.GetAllClientes();
        }

        public async Task<string> InsertClientes(ClientesModel clientesModel)
        {
            return await this._clienteRepository.InsertClientes(clientesModel);
        }

        public async Task<string> UpdateClientes(ClientesModel clientesModel)
        {
            return await this._clienteRepository.UpdateClientes(clientesModel);
        }
    }
}