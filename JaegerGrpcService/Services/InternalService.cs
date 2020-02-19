using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace JaegerGrpcService
{
    public class InternalService : GrpcTest.GrpcTestBase
    {
        private readonly ILogger _logger;
        public InternalService(ILogger<InternalService> logger)
        {
            _logger = logger;
        }
        public override async Task<ResponseDto> Execute(RequestDto request, ServerCallContext context)
        {
            _logger.LogInformation("GRPC: {i}", request.Value);
            await Task.Delay(30).ConfigureAwait(false);
            return new ResponseDto { Result = request.Value - 1 };
        }
    }
}
