namespace AD.Persistence.Domain.Enums;

public enum BusinessTaskStatus
{
    Created = 0,
    OnConfirmation = 10,
    InProgress = 20,
    Success = 30,
    Failure = 40
}