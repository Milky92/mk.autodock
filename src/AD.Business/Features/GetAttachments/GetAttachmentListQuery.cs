using AD.Business.Models.Dto;
using AD.Business.Models.Requests;
using AD.Commons;
using MediatR;

namespace AD.Business.Features.GetAttachments;

public record GetAttachmentListQuery(PageContext<AttachmentListFilter> Context):IRequest<PagedResult<AttachmentGridItemDto>>;