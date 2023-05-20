using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using TareaApi.Data;
using TareaApi.Modelos;

namespace TareaApi.Controllers
{
    [ApiController]
    [Route("Productos")]
    public class Productos : ControllerBase
    {
        [HttpGet]
        [Route("ListarProductos")]
        public dynamic ListarProductos()
        {

            DataTable tProductos = Conexion.Listar("ListarProductos");

            string jsonProductos = JsonConvert.SerializeObject(tProductos);

            return new
            {
                success = true,
                mesage = "exito",
                result = new
                {
                    Productos = JsonConvert.DeserializeObject<List<LIProductos>>(jsonProductos),

                }
            };
        }
        [HttpPost]
        [Route("InsertProductos")]
        public dynamic AgregarProductos(LIProductos pedido)
        {

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Nombre", pedido.Descripcion),
                new Parametro("@Precio", pedido.Precio.ToString()),
                new Parametro("@cantidad", pedido.Existencia.ToString()),

            };
            bool exito = Conexion.Ejecutar("InsertarProducto", parametros);

            return new
            {
                success = exito,
                mesage = exito ? "exito" : "Error al guardar",
                result = ""
            };
        }
    }
}
