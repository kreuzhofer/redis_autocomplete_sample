﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisAutocomplete
{
    internal class Factory
    {
        public static IRedisAutocompleteManager<T> getAutocompleter<T>(string redisConnectionString)
        {
            return new RedisAutocompleteManager<T>(redisConnectionString);
        }
    }
}
