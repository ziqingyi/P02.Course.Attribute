using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P39.Course.dotnetCore.Interface;
using P39.Course.EntityFrameworkCore3.Model;

namespace P39.Course.dotnetCore.Service
{
    public class CategoryService: BaseService, ICategoryService
    {
        public CategoryService(DbContext context):base(context)
        {

        }

        public void Show()
        {
            Console.WriteLine("CategoryService Show()");
            throw new Exception("This is CategoryService Exception");

        }

        public override void Dispose()
        {
            Console.WriteLine("dispose other objects");
            base.Dispose();
        }


        #region Query

        public List<Category> CacheAllCategory()
        {
            List<Category> cachedList = CacheManager.Get<List<Category>>("AllCateogry",
                () => base.Set<Category>().ToList());
            return cachedList;
        }

        public IEnumerable<int> GetDescendantsIdList(string code)
        {
            return this.CacheAllCategory().Where(c => c.Code.StartsWith(code)).Select(c => c.Id);
        }

        public IEnumerable<Category> GetChildList(string code = "root")
        {
            return this.CacheAllCategory().Where(c => c.ParentCode.StartsWith(code));
        }

        #endregion
 





    }
}
