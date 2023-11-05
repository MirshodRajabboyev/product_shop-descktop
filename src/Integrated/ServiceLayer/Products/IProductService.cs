using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Products;

namespace Integrated.ServiceLayer.Products;

public interface IProductService
{
    Task<List<ProductGetViewModel>> GetAllViewAsync(int page);

}
