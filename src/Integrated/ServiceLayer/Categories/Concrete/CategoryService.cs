using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels.Categories;

namespace Integrated.ServiceLayer.Categories.Concrete;

public class CategoryService : ICategoryService
{
    public async Task<List<Category>> GetAllAsync(int page)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, API.BASE_URL + $"common/categories?page={page}");
        request.Headers.Add("Id", "");
        request.Headers.Add("Name", "");
        var content = new StringContent("", null, "text/plain");
        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            List<Category> category = new List<Category>();
            string jsonstring = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Category>>(jsonstring);
            foreach (var item in result)
            {
                category.Add(item);
            }
            return category;
        }
        else return new List<Category>();
    }
}
