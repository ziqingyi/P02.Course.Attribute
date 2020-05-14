using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty.MappingExtend
{
    public class SerializeMapper
    {
        // create new object with serialize and deserialize. 
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            return JsonConvert.DeserializeObject<TOut>(
                JsonConvert.SerializeObject(tIn));
        }

    }
}
