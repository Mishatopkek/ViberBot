﻿using Newtonsoft.Json;
using RestSharp;

namespace ViberBot.Extensions;

public static class RestSharpExtension
{
    public static async Task<T?> ViberRequestAsync<T>(string resource, object? body)
    {
        RestClient client = new RestClient("https://chatapi.viber.com/pa/");
        RestRequest request = new RestRequest(resource);
        //Insert viber token here
        request.AddHeader("X-Viber-Auth-Token", "");
        string stringBody = JsonConvert.SerializeObject(body, Formatting.Indented, new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        });
        request.AddStringBody(stringBody, DataFormat.Json);
        RestResponse<T> responseFromViber = await client.ExecuteAsync<T>(request);
        return responseFromViber.Data;
    }
}