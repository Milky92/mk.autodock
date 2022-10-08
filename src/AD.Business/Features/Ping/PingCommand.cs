using AD.Commons;
using MediatR;

namespace AD.Business.Features.Ping;

public class PingCommand : IRequest<Result<string>>
{
    public PingCommand()
    {
        
    }

    public PingCommand(string message)
    {
        Message = message;
    }
    public string Message { get; set; }
}