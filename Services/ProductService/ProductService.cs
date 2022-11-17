using CajeroMovil.MVVM.Models;
using SQLite;

namespace CajeroMovil.Services.ProductService
{
    public class ProductService : IProductRepository
    {
        public SQLiteAsyncConnection _database;

        public ProductService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<articuloBaseDatos>().Wait();

        }
        public async Task<bool> AddUpdateProductAsync(articuloBaseDatos articulobasedatos)
        {
            if (articulobasedatos.id > 0)
            {
                await _database.UpdateAsync(articulobasedatos);
            }
            else
            {
                await _database.InsertAsync(articulobasedatos);
            }

            return await Task.FromResult(true);

        }

        public async Task<bool> DeleteProductAsync(int prodId)
        {
            await _database.DeleteAsync<articuloBaseDatos>(prodId);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<articuloBaseDatos>> GetArticulosAsync()
        {
            return await Task.FromResult(await _database.Table<articuloBaseDatos>().ToListAsync());
        }

        public async Task<articuloBaseDatos> GetProductAsync(int prodId)
        {
            return await _database.Table<articuloBaseDatos>().Where(p => p.id == prodId).FirstOrDefaultAsync();
        }
    }
}
