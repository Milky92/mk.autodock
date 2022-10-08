using AD.Commons;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AD.Business.Features.Ping;

public class PingCommandHandler:IRequestHandler<PingCommand,Result<string>>
{
    private readonly ILogger<PingCommandHandler> _logger;
    
    public PingCommandHandler(ILogger<PingCommandHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task<Result<string>> Handle(PingCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("PingPong handler started.");
        request.Message = request.Message == "ping" ? "pong" : "ping";
        var res = Result<string>.Ok(request.Message);
        _logger.LogInformation("PingPong handler finish.");
        return await Task.FromResult(res);
    }
}