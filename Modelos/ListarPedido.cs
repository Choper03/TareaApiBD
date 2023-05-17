namespace TareaApi.Modelos
{
    public class ListarPedido
    {
        public string Producto { get; set; }
        public decimal PrecioCosto { get; set; }
        public int Cantidad { get; set; }
        public string Total { get; set; }
        public string Proveedor { get; set; }
        public string Fecha { get; set; }
    }
}
