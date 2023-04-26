using WebApiDemo.Entities;

namespace WebApiDemo.DataAccess
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
    }
}
