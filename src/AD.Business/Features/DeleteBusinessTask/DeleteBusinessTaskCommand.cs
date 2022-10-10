using AD.Commons;
using MediatR;

namespace AD.Business.Features.DeleteBusinessTask;

public record DeleteBusinessTaskCommand(int Id) : IRequest<Result>;
