using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Brands;
using ViewModels.Products;

namespace Integrated.ServiceLayer.Brands;

public interface IBrandService
{
    Task<List<Brand>> GetAllAsync(int page);
}
