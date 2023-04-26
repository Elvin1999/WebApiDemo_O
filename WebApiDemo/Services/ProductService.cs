using WebApiDemo.DataAccess;
using WebApiDemo.Entities;

namespace WebApiDemo.Services
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;
        private ICategoryDal _categoryDal;

        public ProductService(IProductDal productDal, ICategoryDal categoryDal)
        {
            _productDal = productDal;
            _categoryDal = categoryDal;
        }

        public Product Get(int id)
        {
            var product = _productDal.Get(p => p.ProductId == id);
            var category = _categoryDal.Get(c => c.CategoryId == product.CategoryId);
            product.Category=category;
            return product;
        }

        public List<Product> GetProductsWithDetails()
        {
            var products = _productDal.GetList();
            var categories = _categoryDal.GetList();

            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         select new Product
                         {
                             ProductId=p.ProductId,
                             ProductName=p.ProductName,
                             UnitPrice=p.UnitPrice,
                             UnitsInStock=p.UnitsInStock,
                             CategoryId = p.CategoryId,
                             Category=c
                         };
            return result.ToList();
        }
    }
}
