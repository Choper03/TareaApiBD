namespace TareaApi.Modelos
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }    
        public int Cantidad { get; set; }
        public string Fechas { get; set; }
        public string Fecha { get; set; }
    }
}
