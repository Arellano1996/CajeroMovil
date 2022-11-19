
namespace CajeroMovil.MVVM.Models
{
    public class listaArticulos : List<articuloBaseDatos>
    {
        public DateTime Fecha { get; private set; }
        public float Total { get; set; }
        public listaArticulos(DateTime fecha, float total, List<articuloBaseDatos> articulos) :
            base(articulos)
        {
            Fecha = fecha;
            Total = total;
        }
    }
}
