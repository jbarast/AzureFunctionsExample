using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HelloFunction
{
    public class Function1
    {
        private readonly IMessage _message;

        public Function1(IMessage message)
        {
            _message= message;  
        }


        [FunctionName("TwitchFuncion")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "v1/call")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            string country = req.Query["country"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            name = name ?? data?.name;
            country = country ?? data?.country;

            string responseMessage = _message.CreateMessage(name, country);
            _message.BaseMessage.PrintMessage(responseMessage);

            return new OkObjectResult(responseMessage);
        }
    }
}
