﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
   public class MemoryCacheManager:ICacheManager
   {
       //Adapter pattern
         private IMemoryCache _memoryCache;

         public MemoryCacheManager(IMemoryCache memoryCache)
         {
             _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
         }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value,TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key,out _);//data istemiyorum
        }

        public void Remove(string key)
        {
             _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache)
                .GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic
                                                  | System.Reflection.BindingFlags.Instance);//bellekteki EntriesCollection olanı bul
            var cacheEntriesCollection 
                = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;//definationı memeorycache olanları bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }//her bir cache elemanını gez

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);// kurala uyanları temizle
            }
        }
    }
}
