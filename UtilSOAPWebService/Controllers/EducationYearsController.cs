using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference;

namespace UtilSOAPWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationYearsController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public EducationYearsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory; 
        }
        [HttpGet]
        public async Task<Envelope> getEduYear()
        {
            var request = new HttpRequestMessage(HttpMethod.Post,"");
            //request.Headers.Add("Content-Type", "text/xml");
            //request.Headers.Add("charset", "utf-8");
            //request.Headers.Add("Content-Length", "<calculated when request is sent>");
            request.Content = new StringContent(@"<soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:tem=""http://tempuri.org/"">
   < soap:Header >
      < tem:UserCredentials >
         < !--Optional:-->
         < tem:userName > Tahdeer </ tem:userName >
         < !--Optional:-->
         < tem:password > moe@1234 </ tem:password >
      </ tem:UserCredentials >
   </ soap:Header >
   < soap:Body >
      < tem:getEduYear />
   </ soap:Body >
</ soap:Envelope > ",Encoding.UTF8,"text/xml");
       
        var client = _clientFactory.CreateClient("webService");
        

        var response = await client.SendAsync(request);
            var serializer = new XmlSerializer(typeof(Envelope));
            using var responseStream = await response.Content.ReadAsStreamAsync();
            return  (Envelope)serializer.Deserialize(responseStream);
        }
    }
}
