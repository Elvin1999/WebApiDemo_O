using WebApiDemo.Entities;

namespace WebApiDemo.Services
{
    public interface IProductService
    {
        List<Product> GetProductsWithDetails();
        Product Get(int id);
    }
}
