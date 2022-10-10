using AD.Business.Models.Dto;
using AD.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AD.Business.Features.UploadFiles;

public record UploadFilesCommand(int TaskId,IFormFile File) : IRequest<Result<AttachmentDto>>;
