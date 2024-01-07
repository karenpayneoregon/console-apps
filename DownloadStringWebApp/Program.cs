using System;
using System.Data.SqlTypes;
using System.Net;
using System.Net.WebSockets;

#pragma warning disable SYSLIB0014
#pragma warning disable SYSLIB0014

namespace DownloadStringWebApp;

// C:\OED\DotnetLand\VS2019\Misc\KP_ConsoleAppJokes
internal partial class Program
{
    static async Task Main(string[] args)
    {
        var address = "https://v2.jokeapi.dev/joke/Programming";
        await File.WriteAllTextAsync("data1.json", await Read1Async(address));
        await File.WriteAllTextAsync("data2.json", await Read2Async(address));
        await File.WriteAllTextAsync("data3.json", await HttpHelper.ReadResponse(address));


    }
    public static async Task<string> Read1Async(string url)
    {
        using WebClient client = new();
        return await client.DownloadStringTaskAsync(new Uri(url));
    }
    public static async Task<string> Read2Async(string url)
    {
        HttpClient _httpClient = new();
        return await _httpClient.GetStringAsync(url);
    }
}

public static class HttpHelper
{
    private static readonly HttpClient _httpClient = new();

    public static async Task<string> ReadResponse(string uri)
    {
        return await _httpClient.GetStringAsync(uri);
    }
}