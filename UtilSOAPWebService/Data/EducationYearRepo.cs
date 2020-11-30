using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class EducationYearRepo 
{
    private readonly IHttpClientFactory _clientFactory;


    public EducationYearRepo(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IEnumerable<string>> getEduYears()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,"");
       
        var client = _clientFactory.CreateClient("webService");
        

        var response = await client.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync
            <IEnumerable<string>>(responseStream);
        
    }
}