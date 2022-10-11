using AD.Business.Models.Dto;
using AD.Commons;
using MediatR;

namespace AD.Business.Features.GetFile;

public record GetFileQuery(int TaskId, int AttachmentId) : IRequest<Result<FileDto>>;
