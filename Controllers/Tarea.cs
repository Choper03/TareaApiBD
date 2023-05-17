using Microsoft.AspNetCore.Mvc;
using TareaApi.Data;
using System.Data;
using Newtonsoft.Json;
using TareaApi.Modelos;

namespace TareaApi.Controllers
{
    [ApiController]
    [Route("Tarea")]
    public class Tarea : ControllerBase
    {
        [HttpGet]
        [Route("ListarProductos")]
        public dynamic ListarProductos ()
        {
            DataTable tProductos = Conexion.Listar("spSeleccionarProductos");
            //DataTable tProveedores = Conexion.Listar("spSeleccionarProveedores");

            string jsaonProductos = JsonConvert.SerializeObject(tProductos);
            //string jsonProveedores = JsonConvert.SerializeObject(tProveedores);

            return new
            {
                success = true,
                mesage = "exito",
                result = new
                {
                    productos = JsonConvert.DeserializeObject<List<Productos>>(jsaonProductos),
                    //proveedores = jsonProveedores
                }
            };
        }
        [HttpGet]
        [Route("ListarProveedores")]
        public dynamic ListarProveedores()
        {
            
            DataTable tProveedores = Conexion.Listar("spSeleccionarProveedores");
            
            string jsonProveedores = JsonConvert.SerializeObject(tProveedores);

            return new
            {
                success = true,
                mesage = "exito",
                result = new
                {
                    proveedores = JsonConvert.DeserializeObject<List<Proveedores>>(jsonProveedores),
                    
                }
            };
        }
        [HttpGet]
        [Route("ListarPedidos")]
        public dynamic ListarPedidos()
        {

            DataTable tPedidos = Conexion.Listar("spSeleccionarPedidos");

            string jsonPedidos = JsonConvert.SerializeObject(tPedidos);

            return new
            {
                success = true,
                mesage = "exito",
                result = new
                {
                    proveedores = JsonConvert.DeserializeObject<List<ListarPedido>>(jsonPedidos),

                }
            };
        }
        [HttpPost]
        [Route("InsertPedidos")]
        public dynamic AgregarPedido(Pedidos pedido)
        {
         
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@id", pedido.Id.ToString()),
                new Parametro("@idproductos", pedido.IdProducto.ToString()),
                new Parametro("@idproveedores", pedido.IdProveedor.ToString()),
                new Parametro("@cantidad", pedido.Cantidad.ToString()),
                new Parametro("@fechas", pedido.Fechas),
                new Parametro("@fecha", pedido.Fecha)

            };
            bool exito = Conexion.Ejecutar("InsertarPedido", parametros);

            return new
            {
                success = exito,
                mesage = exito ? "exito" : "Error al guardar",
                result = ""
            };
        }
    }
}
