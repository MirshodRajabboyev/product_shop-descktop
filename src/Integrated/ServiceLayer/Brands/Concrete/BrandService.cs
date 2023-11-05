using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels.Brands;

namespace Integrated.ServiceLayer.Brands.Concrete;

public class BrandService : IBrandService
{
    public async Task<List<Brand>> GetAllAsync(int page)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync(API.COMMON_BRANDS +
                $"?page={page}");
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                IEnumerable<Brand> readBrands = JsonConvert.DeserializeObject<IEnumerable<Brand>>(responseData);
                List<Brand> brand = new List<Brand>();
                foreach (var i in readBrands)
                {
                    brand.Add(new Brand()
                    {
                        Id = i.Id,
                        Name = i.Name
                    });
                }
                return brand;
                // Process the itemList as needed
            }
            else
            {
                // Handle the response error accordingly
                // For example, throw an exception or return a default value
                return null;
            }

        }
    }
}
