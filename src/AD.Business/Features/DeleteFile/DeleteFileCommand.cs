using AD.Commons;
using MediatR;

namespace AD.Business.Features.DeleteFile;

public record DeleteFileCommand(int TaskId,int AttachmentId):IRequest<Result>;