namespace AD.Business.Models.Dto;

public record FileDto(string ContentType, Stream Content,string FileName);
