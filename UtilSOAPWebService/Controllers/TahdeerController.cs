using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UtilSOAPWebService.Controllers
{
    [Route("api/Tahdeer")]
    [ApiController]
    public class TahdeerController : ControllerBase
    {
        private TahdeerSoapClient soapClient = new TahdeerSoapClient();

        [HttpGet]
        public getallDeptInstEMPResponse getallDeptInstEMP()
        {
            return soapClient.getallDeptInstEMPAsync(new UserCredentials() { userName= "Tahdeer", password = "moe@1234"},1).Result;
        }
    }
}
