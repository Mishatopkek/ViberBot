using Microsoft.EntityFrameworkCore;
using ViberBot.Contexts;
using ViberBot.Entities;
using ViberBot.Extensions;
using ViberBot.Models.SendMessage;
using ViberBot.ViberService.Mapper;

namespace ViberBot.ViberService;

public class SendMessageService : ISendMessageService
{
    private readonly MsSqlContext _context;

    public SendMessageService(MsSqlContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse> WalkSum(string userId, string imei)
    {
        ServiceResponse serviceResponse = new ServiceResponse();
        
        Statistic? sumStatistic = _context.Statistics
            .FromSqlRaw($"EXEC show_sum_statistics_by_id {imei}").AsEnumerable().FirstOrDefault();
        if (sumStatistic!.Id == 0)
        {
            serviceResponse.Message = "Imei does not exist";
            return serviceResponse;
        }
        
        MessageBody messageBody = SendMessageMapper.GenerateMessageBodyForShowSumStatistic(userId, sumStatistic, imei);
        
        return await SendRequest(messageBody);
    }

    public async Task<ServiceResponse> WalkTop(string userId, string imei)
    {
        ServiceResponse serviceResponse = new ServiceResponse();

        IEnumerable<Statistic> topStatistics = _context.Statistics
            .FromSqlRaw($"EXEC show_top_statistics_by_id {imei}").AsEnumerable();
        if (!topStatistics.Any())
        {
            serviceResponse.Message = "Imei does not exist";
            return serviceResponse;
        }
        
        MessageBody messageBody = SendMessageMapper.GenerateMessageBodyForShowTopStatistic(userId, topStatistics);
        
        return await SendRequest(messageBody);
    }

    public async Task<ServiceResponse> SendMessage(string userId, string text)
    {
        
        MessageBody messageBody = SendMessageMapper.GenerateMessageBodyForMessage(userId, text);
        
        return await SendRequest(messageBody);
    }

    public async Task<ServiceResponse> WalkBack(string userId)
    {
        MessageBody messageBody = SendMessageMapper.GenerateMessageBodyForMessage(userId, "Введите IMEI");
        
        return await SendRequest(messageBody);
    }
    private async Task<ServiceResponse> SendRequest(object messageBody)
    {
        ServiceResponse serviceResponse = new ServiceResponse();
        MessageResponse? viberResponse = 
            await RestSharpExtension.ViberRequestAsync<MessageResponse>("send_message", messageBody);
        
        if (viberResponse == null) throw new NullReferenceException("ViberResponse is null");
        if (viberResponse.Status != 0)
        {
            serviceResponse.Message = viberResponse.StatusMessage;
            return serviceResponse;
        }
        serviceResponse.Success = true;
        return serviceResponse;
    }
}