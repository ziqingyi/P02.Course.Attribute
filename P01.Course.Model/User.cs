using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.Model
{
    public class User : BaseModel
    {
        public string Name { set; get; }

        public string Account { set; get; }

        public string Password { set; get; }

        public string Email { set; get; }

        public string Mobile { set; get; }

        public int CompanyId { set; get; }

        public string CompanyName { set; get; }

        /// <summary>
        ///   0 normal 1freeze 2deleted
        /// </summary>
        public int State { set; get; }

        /// <summary>
        ///  user type: 1 normal 2 admin 4 root
        /// </summary>
        public int UserType { set; get; }

        public DateTime LastLoginTime { set; get; }

        public DateTime CreateTime { set; get; }

        public int CreatorId { set; get; }

        public int LastModifierId { set; get; }

        public DateTime LastModifyTime { set; get; }

    }
}
