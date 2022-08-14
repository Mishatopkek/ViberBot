using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using ViberBot.Extensions;
using ViberBot.Models;
using ViberBot.ViberService;

namespace ViberBot.Controllers;

[ApiController]
[Route("[controller]")]
public class ViberController : ControllerBase
{
    private readonly ISendMessageService _sendMessageService;

    public ViberController(ISendMessageService sendMessageService)
    {
        _sendMessageService = sendMessageService;
    }

    [HttpGet]
    public IActionResult Get(object obj)
    {
        return Ok();
    }
    [HttpPost]
    public async Task<IActionResult> Post(MessageCallback response)
    {
        if (response.Event == "webhook") return Ok();
        if (response.Message == null) return BadRequest();
        string[] strings = response.Message.Text.Split(" ");
        ServiceResponse serviceResponse = new ServiceResponse();
        switch (strings[0])
        {
            case "top":
                if (ValidateImei(strings[1]))
                {
                    serviceResponse = await _sendMessageService.WalkTop(response.Sender!.Id!, strings[1]);
                    break;
                }
                serviceResponse.Message = "User wrote not a IMEI";
                break;
            case "back":
                serviceResponse = await _sendMessageService.SendMessage(response.Sender!.Id!, "Введите IMEI");
                break;
            default:
                if (ValidateImei(strings[0]))
                {
                    serviceResponse = await _sendMessageService.WalkSum(response.Sender!.Id!, strings[0]);
                    break;
                }
                serviceResponse.Message = "User wrote not a IMEI";
                break;
        }

        if (!serviceResponse.Success)
        {
            await _sendMessageService.SendMessage(response.Sender!.Id!, "Попробуйте ещё раз");
        }
        return Ok( );
    }
    
    private static bool ValidateImei(string imei)
    {
        Regex regex = new Regex(@"^\d{15}$");
        return regex.IsMatch(imei);
    }
}