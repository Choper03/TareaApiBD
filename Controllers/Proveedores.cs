using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using TareaApi.Data;
using TareaApi.Modelos;

namespace TareaApi.Controllers
{
    [ApiController]
    [Route("Proveedores")]
    public class Proveedores :ControllerBase
    {
        [HttpGet]
        [Route("ListarProveedores")]
        public dynamic ListarProveedores()
        {

            DataTable tProveedores = Conexion.Listar("ListarProveedores");

            string jsonProveedores = JsonConvert.SerializeObject(tProveedores);

            return new
            {
                success = true,
                mesage = "exito",
                result = new
                {
                    proveedores = JsonConvert.DeserializeObject<List<LIProveedores>>(jsonProveedores),

                }
            };
        }
        [HttpPost]
        [Route("InsertProveedores")]
        public dynamic AgregarProveedores(LIProveedores pedido)
        {

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Nombre", pedido.Nombre),
                new Parametro("@Apellido", pedido.Apellido),
                new Parametro("@Nit", pedido.Nit.ToString()),

            };
            bool exito = Conexion.Ejecutar("InsertarProveedores", parametros);

            return new
            {
                success = exito,
                mesage = exito ? "exito" : "Error al guardar",
                result = ""
            };
        }
    }
}
