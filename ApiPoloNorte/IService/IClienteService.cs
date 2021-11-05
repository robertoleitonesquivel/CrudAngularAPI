using ApiPoloNorte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPoloNorte.IService
{
    public interface IClienteService
    {
        Task<List<ClientesModel>> GetAllClientes();
        Task<string> InsertClientes(ClientesModel clientesModel);
        Task<string> UpdateClientes(ClientesModel clientesModel);
        Task<string> DeleteClientes(string cedula);
    }
}
