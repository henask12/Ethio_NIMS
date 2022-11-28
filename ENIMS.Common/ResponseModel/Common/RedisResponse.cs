using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENIMS.Common
{
    public class RedisResponse<T>
    {
        public T Value { get; set; }
        public bool IsFound { get; set; }
    }
}
