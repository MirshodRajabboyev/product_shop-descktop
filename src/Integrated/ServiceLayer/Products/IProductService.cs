using System.Collections.Generic;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.Products;

namespace Integrated.ServiceLayer.Products;

public interface IProductService
{
    Task<(List<ProductGetViewModel> productGetViewModels, Pagination pageData)> GetAllViewAsync(int page);
}
