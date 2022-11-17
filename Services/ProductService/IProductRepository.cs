using CajeroMovil.MVVM.Models;

namespace CajeroMovil.Services.ProductService
{
    internal interface IProductRepository
    {
        Task<bool> AddUpdateProductAsync(articuloBaseDatos articulobasedatos);
        Task<bool> DeleteProductAsync(int prodId);
        Task<articuloBaseDatos> GetProductAsync(int prodId);
        Task<IEnumerable<articuloBaseDatos>> GetArticulosAsync();
    }
}
