using SQLite;

namespace CajeroMovil.MVVM.Models
{
    [Table("articulos")]
    public class articuloBaseDatos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string nombre { get; set; }
        public float precio { get; set; }
        public DateTime fecha { get; set; }
    }
}
