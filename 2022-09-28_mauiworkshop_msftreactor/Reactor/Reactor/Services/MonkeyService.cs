using System;
using System.Net.Http.Json;
using Reactor.Models;
using Reactor.Services;

namespace Reactor.Services
{
    public interface IMonkeyService
    {
        Task<List<Monkey>> GetMonkeys();
    }


    public class MonkeyService : IMonkeyService
    {
        readonly HttpClient httpClient = new();


        public async Task<List<Monkey>> GetMonkeys()
        {
            var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
            var monkeys = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            return monkeys;
        }
    }
}

//HttpClient httpClient;
//public MonkeyService()
//{
//    this.httpClient = new HttpClient();
//}

//List<Monkey> monkeyList;
//public async Task<List<Monkey>> GetMonkeys()
//{
//    if (monkeyList?.Count > 0)
//        return monkeyList;

//    // Online
//    var response = await httpClient.GetAsync("https://www.montemagno.com/monkeys.json");
//    if (response.IsSuccessStatusCode)
//    {
//        monkeyList = await response.Content.ReadFromJsonAsync<List<Monkey>>();
//    }
//    // Offline
//    /*using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
//    using var reader = new StreamReader(stream);
//    var contents = await reader.ReadToEndAsync();
//    monkeyList = JsonSerializer.Deserialize<List<Monkey>>(contents);
//    */
//    return monkeyList;
//}