using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.DTOs;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public HttpCommandDataClient(HttpClient client, IConfiguration configuration)
        {
            _httpClient = client;    
            _config = configuration;
        }
        public async Task SendPlatformToCommand(PlatformReadDTO plat)
        {
            var httpContent= new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json"
            );
            //Take it from Configuration
            var response = await _httpClient.PostAsync($"{_config["CommandService"]}", httpContent);
            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to Command Service was Ok.");
            }
            else{
                Console.WriteLine("--> Sync Post to Command Service was NOT Ok.");
            }
            
        }
    }
}