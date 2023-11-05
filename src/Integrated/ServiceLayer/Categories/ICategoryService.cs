using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Brands;
using ViewModels.Categories;

namespace Integrated.ServiceLayer.Categories;

public interface ICategoryService
{
    Task<List<Category>> GetAllAsync(int page);
}
