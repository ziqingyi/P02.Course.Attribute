using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Models
{
    public class Page<T>
    {
        //current page index
        public int PageIndex { get; set; } = 1;

        //num of record per page
        public int PageSize { get; set; } = 5;


        //total num of records
        public int DataCount { get; set; }


        //total num of pages, can be calculated
        public int PagesCount { get; set; }

        public List<T> DataList { get; set; }


        public Page()
        {

        }

        public Page(int pageIndex, int pageSize, int dataCount, List<T> dataList)
        {
            this.PageIndex = pageIndex;

            this.PageSize = pageSize;

            this.DataCount = dataCount;

            int i = dataCount / (pageSize > 0 ? pageSize : 1);

            this.PagesCount = dataCount % (pageSize > 0 ? pageSize : 1) == 0 ? i : i + 1;

            this.DataList = dataList;

        }

    }
}
