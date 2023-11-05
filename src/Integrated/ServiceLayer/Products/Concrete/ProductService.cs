using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels.Common;
using ViewModels.Products;

namespace Integrated.ServiceLayer.Products.Concrete;

public class ProductService : IProductService
{
    public async Task<(List<ProductGetViewModel> productGetViewModels, Pagination pageData)> GetAllViewAsync(int page)
    {
        using (var client = new HttpClient())
        {
            Pagination pagination = new Pagination();
            var response = await client.GetAsync(API.BASE_URL + $"common/products/All?page={page}");
            response.EnsureSuccessStatusCode();


            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.TryGetValues("x-pagination", out var headerValues))
                {
                    string headerValue = headerValues.FirstOrDefault();
                    pagination = Newtonsoft.Json.JsonConvert.DeserializeObject<Pagination>(headerValue);

                }

                var responseData = await response.Content.ReadAsStringAsync();
                IEnumerable<ProductGetViewModel> readProducts = JsonConvert.DeserializeObject<IEnumerable<ProductGetViewModel>>(responseData);
                List<ProductGetViewModel> productList = new List<ProductGetViewModel>();
                foreach (var i in readProducts)
                {
                    productList.Add(new ProductGetViewModel()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        BrandId = i.BrandId,
                        BrandName = i.BrandName,
                        CategoryId = i.CategoryId,
                        CategoryName = i.CategoryName,
                        UnitPrice = i.UnitPrice,
                        Description = i.Description,
                        CreatedAt = i.CreatedAt,
                        UpdatedAt = i.UpdatedAt
                    });
                }
                return (productList, pageData: pagination);
            }
            else
            {
                return (new List<ProductGetViewModel>(), new Pagination());
            }
        }

        //var client = new HttpClient();
        //var request = new HttpRequestMessage(HttpMethod.Get, API.BASE_URL + $"common/products/All?page={page}");
        //request.Headers.Add("Id", "");
        //request.Headers.Add("CategoryId", "");
        //request.Headers.Add("BrandId", "");
        //request.Headers.Add("Price", "");
        //request.Headers.Add("Name", "");
        //request.Headers.Add("Description", "");
        //request.Headers.Add("CreatedAt", "");
        //var content = new StringContent("", null, "text/plain");
        //request.Content = content;
        //var response = await client.SendAsync(request);
        //if (response.IsSuccessStatusCode)
        //{
        //    List<ProductGetViewModel> productList = new List<ProductGetViewModel>();
        //    string jsonstring = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<List<ProductGetViewModel>>(jsonstring);
        //    foreach (var item in result)
        //    {
        //        productList.Add(item);
        //    }
        //    return productList;
        //}
        //else return new List<ProductGetViewModel>();
    }
}
