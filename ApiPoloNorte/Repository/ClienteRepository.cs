using ApiPoloNorte.IRepostory;
using ApiPoloNorte.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ApiPoloNorte.Repository
{
    public class ClienteRepository : Conexion, IClienteRepository
    {
        public async Task<string> DeleteClientes(string cedula)
        {
            try
            {
                using (var conn = GetConexion())
                {
                    var query = "DELETE CLIENTES WHERE CEDULA = @CEDULA";
                    await conn.ExecuteAsync(query, new { CEDULA = cedula }, commandType: CommandType.Text);
                }
                return "Eliminado con éxito.";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ClientesModel>> GetAllClientes()
        {
            List<ClientesModel> list;
            try
            {
                using (var conn = GetConexion())
                {
                    var query = "SELECT CEDULA, NOMBRE FROM CLIENTES";
                    list = (List<ClientesModel>)await conn.QueryAsync<ClientesModel>(query, commandType: CommandType.Text);
                }
                if (list == null) throw new Exception("No se encontraron resultados");
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public async Task<string> InsertClientes(ClientesModel clientesModel)
        {
            try
            {
                using (var conn = GetConexion())
                {
                    var query = "INSERT INTO CLIENTES(CEDULA,NOMBRE) VALUES (@CEDULA,@NOMBRE)";
                    await conn.ExecuteAsync(query, new { CEDULA = clientesModel.Cedula, NOMBRE = clientesModel.Nombre }, commandType: CommandType.Text);
                }
                return "Guardado con éxito.";
            }
            catch (Exception ex)
            {
                SqlException sqlex = ex as SqlException;

                if (sqlex != null && sqlex.Number == 2627)
                    throw new Exception("El registro ya existe en el sistema.");
                else
                    throw;
            }
        }

        public async Task<string> UpdateClientes(ClientesModel clientesModel)
        {
            try
            {
                using (var conn = GetConexion())
                {
                    var query = "UPDATE CLIENTES SET NOMBRE = @NOMBRE WHERE CEDULA = @CEDULA";
                    await conn.ExecuteAsync(query, new { NOMBRE = clientesModel.Nombre, CEDULA = clientesModel.Cedula }, commandType: CommandType.Text);
                }
                return "Actualizado con éxito.";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}