using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common
{
    public static class RedisCacheExtensions
    {
        public static async Task<T> GetAsync<T>(this IDatabase cache, string key)
        {
            try
            {
                var value = await cache.StringGetAsync(key);
                return Deserialize<T>(value);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public static async Task SetAsync(this IDatabase cache, string key, object value, TimeSpan expiry)
        {
            try
            {
                if (await cache.StringSetAsync(key, Serialize(value), expiry))
                {

                }
 
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        static byte[] Serialize(object o)
        {
            byte[] objectDataAsStream = null;
            if (o != null)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, o); objectDataAsStream = memoryStream.ToArray();
                }
            }
            return objectDataAsStream;
        }
        static T Deserialize<T>(byte[] stream)
        {
            T result = default(T);
            if (stream != null)
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream memoryStream = new MemoryStream(stream))
                {
                    result = (T)binaryFormatter.Deserialize(memoryStream);
                }
            }
            return result;
        }
    }
}
