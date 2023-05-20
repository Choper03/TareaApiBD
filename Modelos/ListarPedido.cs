namespace TareaApi.Modelos
{
    public class ListarPedido
    {
        public string Factura { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }
        public string Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
