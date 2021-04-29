using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Models
{
    public class MenuInfo
    {
        public Guid MenuGuid { get; set; }
        public string MenuName { get; set; }
        public string Ico { get; set; }
        public string Url { get; set; }
        public bool IsLeaf { get; set; }
        public List<MenuInfo> Submenu { get; set; }
    }
}
