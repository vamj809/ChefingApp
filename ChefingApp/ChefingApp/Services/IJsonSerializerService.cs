using System;
using System.Collections.Generic;
using System.Text;

namespace ChefingApp.Services
{
    public interface IJsonSerializerService
    {
        string Serialize(object payload);

        T Deserialize<T>(string payload);
    }
}
