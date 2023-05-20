using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using TareaApi.Data;
using TareaApi.Modelos;

namespace TareaApi.Controllers
{
    [ApiController]
    [Route("Pedidos")]
    public class Pedidos : ControllerBase
    {
        [HttpGet]
        [Route("ListarPedidos")]
        public dynamic ListarPedidos()
        {

            DataTable tPedido = Conexion.Listar("ListarPeido");

            string jsonPedido = JsonConvert.SerializeObject(tPedido);

            return new
            {
                success = true,
                mesage = "exito",
                result = new
                {
                    proveedores = JsonConvert.DeserializeObject<List<ListarPedido>>(jsonPedido),

                }
            };
        }
        [HttpPost]
        [Route("InsertEncbezado")]
        public dynamic AgregarEncabezado(Encabezado pedido)
        {

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Numero_Factura", pedido.Factura_No.ToString()),
                new Parametro("@Proveedor", pedido.Cod_Proveedor.ToString()),
                new Parametro("@Fecha", pedido.Fecha),

            };
            bool exito = Conexion.Ejecutar("InsertarEncabezado", parametros);

            return new
            {
                success = exito,
                mesage = exito ? "exito" : "Error al guardar",
                result = ""
            };
        }
        [HttpPost]
        [Route("InsertDetalle")]
        public dynamic AgregarDetalle(Detalle pedido)
        {

            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@Encabezado", pedido.Encabezado_cod.ToString()),
                new Parametro("@Producto", pedido.Producto_cod.ToString()),
                new Parametro("@Cantidad", pedido.Cantidad.ToString()),

            };
            bool exito = Conexion.Ejecutar("InsertarDetalle", parametros);

            return new
            {
                success = exito,
                mesage = exito ? "exito" : "Error al guardar",
                result = ""
            };
        }
    }
}
