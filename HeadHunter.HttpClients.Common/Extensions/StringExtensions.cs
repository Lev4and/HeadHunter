﻿using Newtonsoft.Json;

namespace HeadHunter.HttpClients.Common.Extensions
{
    public static class StringExtensions
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);

            //try
            //{
            //    return JsonConvert.DeserializeObject<T>(json);
            //}
            //catch (Exception ex)
            //{
            //    return Activator.CreateInstance<T>();
            //}
        }
    }
}
