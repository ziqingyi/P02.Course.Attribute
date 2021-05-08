using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace P37.Course.Web.Core.Models
{
    //LayUI require property name using lower case letter 
    //C# property start with capital letter, so use JsonProperty for converting to Json.
    public class TreeResultData
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("checked")] 
        public bool Checked { get; set; } = false;

        [JsonProperty("disabled")] 
        public bool Disabled { get; set; } = true;   //whether able to select or tick

        [JsonProperty("spread")]
        public bool Spread { get; set; } // Spread the tree by default? 

        [JsonProperty("children")]
        public List<TreeResultData> Children { get; set; }


    }
}
