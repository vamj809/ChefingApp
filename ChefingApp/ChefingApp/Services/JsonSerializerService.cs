using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace ChefingApp.Services
{
    public class JsonSerializerService : IJsonSerializeService
    {
        private readonly JsonSerializerOptions _options;
        public JsonSerializerService()
        {
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }
        public T Deserialize<T>(string payload) => JsonSerializer.Deserialize<T>(payload, _options);

        public string Serialize(object payload) => JsonSerializer.Serialize(payload, _options);
    }
}
