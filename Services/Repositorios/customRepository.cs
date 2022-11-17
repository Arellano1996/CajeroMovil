using CajeroMovil.MVVM.Models;
using SQLite;

namespace CajeroMovil.Services.Repositorios
{
    public class customRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public customRepository()
        {
            connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            connection.CreateTable<articuloBaseDatos>();
        }

        public void AddorUpdate(articuloBaseDatos newabd)
        {
            int result = 0;
            try
            {
                if (newabd.id != 0)
                {
                    result = connection.Update(newabd);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(newabd);
                    StatusMessage = $"{result} row(s) added";
                }

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<articuloBaseDatos> GetAll()
        {
            try
            {
                return connection.Table<articuloBaseDatos>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public articuloBaseDatos Get(int id)
        {
            try
            {
                return connection.Table<articuloBaseDatos>().
                    FirstOrDefault(x => x.id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void Delete(int artid)
        {
            try
            {
                var articulo = Get(artid);
                connection.Delete(articulo);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

        }
    }
}
