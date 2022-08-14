using ViberBot.Extensions;

namespace ViberBot.ViberService;

public interface ISendMessageService
{
    Task<ServiceResponse> WalkSum(string userId, string imei);
    Task<ServiceResponse> WalkTop(string userId, string imei);
    Task<ServiceResponse> SendMessage(string userId, string text);
}