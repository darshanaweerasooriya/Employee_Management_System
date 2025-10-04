using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;

namespace EmployeeManagement.Caching
{
    internal class CacheItem
    {
        public object Value { get; set; }
        public DateTime? ExpiryUtc { get; set; }
    }
    public class CacheHelper
    {
        private static readonly ConcurrentDictionary<string, CacheItem> _cache = new ConcurrentDictionary<string, CacheItem>();

        public static T Cached<T>(String key, Func<T> factory, int minutes = 5)
        {
            if (_cache.TryGetValue(key, out var exisiting))
            {
                if (!exisiting.ExpiryUtc.HasValue || exisiting.ExpiryUtc > DateTime.UtcNow)
                    return (T)exisiting.Value;
                _cache.TryRemove(key, out _);
            }
            var data = factory();
            var item = new CacheItem
            {
                Value = data,
                ExpiryUtc = DateTime.UtcNow.AddMinutes(minutes)
            };
            _cache[key] = item;
            return data;
        }

        // chached untill removed

        public static T CachedLong<T>(string key, Func<T> factory)
        {
            if (_cache.TryGetValue(key, out var exisiting))
            {
                return (T)exisiting.Value;
            }

            var data = factory();
            var item = new CacheItem { Value = data, ExpiryUtc = null };
            _cache[key] = item;
            return data;
        }

        public static void Remove(string key)
        {
            _cache.TryRemove(key, out _);
        }
    }
}