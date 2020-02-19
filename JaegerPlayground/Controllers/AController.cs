using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using JaegerGrpcService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JaegerPlayground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AController : ControllerBase
    {
        private readonly IHttpClientFactory _factory;

        public AController(IHttpClientFactory factory, 
            ILogger<AController> logger)
        {
            this._factory = factory;
            _logger = logger;
        }

        private readonly ILogger _logger;

        [HttpGet]
        public async Task<int> GetXAsync()
        {
            _logger.LogInformation("Web Start");

            await Task.Delay(100).ConfigureAwait(false);

            using var channel = GrpcChannel.ForAddress("https://localhost:5002");
            var client = new JaegerGrpcService.GrpcTest.GrpcTestClient(channel);
            var res = await client.ExecuteAsync(new RequestDto { Value = 10 });
            _logger.LogInformation("Web End");
            
            return res.Result;
        }
    }
}
