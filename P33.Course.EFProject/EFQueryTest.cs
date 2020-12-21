using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using P33.Course.Model;
using P33.Course.Model.Models;

namespace P33.Course.EFProject
{
    public class EFQueryTest
    {
        public static void Show()
        {
            using (JDDbContext dbContext = new JDDbContext())
            {
                {
                    //query by linq using lambda expression
                    var list = dbContext.Users.Where(
                        u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id));

                    foreach (User user in list)
                    {
                        Console.WriteLine(user.Id + " " + user.Name);
                    }
                }
                {
                    //query by linq, exactly same from compiler
                    var list = from u in dbContext.Users
                               where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                               select u;

                    foreach (User user in list)
                    {
                        Console.WriteLine(user.Id + " " + user.Name);
                    }
                }
                {
                    //query with skip and take, can use for paging
                    var list = dbContext.Users
                        .Where(u => new int[] {1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17}.Contains(u.Id))
                        .OrderBy(u => u.Id)
                        .Select(u => new
                        {
                            id = u.Id,
                            name = u.Name,
                            Account = u.Account,
                            Pwd = u.Password
                        }).Skip(3).Take(5);

                    foreach (var user in list)
                    {
                        Console.WriteLine(user.id + " " + user.name + " Login: " + user.Account + " " + user.Pwd);
                    }

                }
                {
                    //linq : orderby 
                    var list = (from u in dbContext.Users
                        where new int[] {1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17}.Contains(u.Id)
                        orderby u.Id
                        select new
                        {
                            id = u.Id,
                            name = u.Name,
                            Account = u.Account,
                            Pwd = u.Password
                        }).Skip(3).Take(5);

                    foreach (var user in list)
                    {
                        Console.WriteLine(user.id + " " + user.name + " Login: " + user.Account + " " + user.Pwd);
                    }
                }
                {
                    //filter by multiple where
                    var list = dbContext.Users.Where(u => u.Name.StartsWith("test") && u.Name.EndsWith("8"))
                        .Where(u => u.Account == "40171")
                        .Where(u => u.Name.Length < 10)
                        .OrderBy(u => u.Id);

                    foreach (var user in list)
                    {
                        Console.WriteLine(user.Id + " " + user.Name + " Login: " + user.Account + " " + user.Password);
                    }

                }
                {
                    //linq:  inner join
                    var list = from u in dbContext.Users
                        join c in dbContext.Companies
                            on u.CompanyId equals c.Id
                        where new int[] {1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17}.Contains(u.Id)
                        select new
                        {
                            id = u.Id,
                            name = u.Name,
                            Account = u.Account,
                            Pwd = u.Password
                        };

                    foreach (var user in list)
                    {
                        Console.WriteLine(user.id + " " + user.name + " Login: " + user.Account + " " + user.Pwd);
                    }
                }
                {
                    //linq: left (outer) join and fill in default values

                    /* how to use the DefaultIfEmpty method on the results of a group join to perform a left outer join.
                     * The first step in producing a left outer join of two collections is to perform an inner join by using a group join.
                     *
                     * The second step is to include each element of the first (left) collection in the result set
                     * even if that element has no matches in the right collection.
                     * This is accomplished by calling DefaultIfEmpty on each sequence of matching elements from the group join. I
                     */

                    var list = from u in dbContext.Users
                        join c in dbContext.Categories
                            on u.CompanyId equals c.Id
                            into ucList
                        from uc in ucList.DefaultIfEmpty()
                        where new int[] {1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17}.Contains(u.Id)
                        select new
                        {
                            id = u.Id,
                            name = u.Name,
                            Account = u.Account,
                            Pwd = u.Password
                        };

                    foreach (var user in list)
                    {
                        Console.WriteLine(user.id + " " + user.name + " Login: " + user.Account + " " + user.Pwd);
                    }
                }



            }


            using (JDDbContext dbContext = new JDDbContext())
            {

                {
                    DbContextTransaction trans = null;
                    try
                    {
                        trans = dbContext.Database.BeginTransaction();
                        string sql = "Update [User] Set Name = 'Admin' where Id= @Id ";
                        SqlParameter parameter = new SqlParameter("@Id",9 );
                        dbContext.Database.ExecuteSqlCommand(sql, parameter);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (trans != null)
                            trans.Rollback();
                        Console.WriteLine(ex);
                        throw ex;
                    }
                    finally
                    {
                        trans.Dispose();

                    }
                }

                {
                    DbContextTransaction trans = null;
                    try
                    {
                        trans = dbContext.Database.BeginTransaction();
                        string sql = @"SELECT * FROM [User] WHERE Id=@Id";
                        SqlParameter parameter = new SqlParameter("@Id",1);
                        List<User> userList = dbContext.Database.SqlQuery<User>(sql, parameter).ToList();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (trans != null)
                            trans.Rollback();
                        Console.WriteLine(ex);
                        throw ex;
                    }
                    finally
                    {
                        trans.Dispose();
                    }
                }

            }

        }

    }


}
