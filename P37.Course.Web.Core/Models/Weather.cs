using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Models
{
    public class Weather
    {
        public DateTime ShowDate { get; set; }

        public string Icon { get; set; }

        public string Temperature { get; set; }

        public string WindSpeed { get; set; }

        public string City { get; set; }

        public string Remark { get; set; }

    }
}
