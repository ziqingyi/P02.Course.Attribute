using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace P34.Course.EF_IOC_Project
{
    public class UnitOfWork
    {
        public static void Invoke(Action action)
        {
            TransactionScope transaction = null;
            try
            {
                transaction = new TransactionScope();
                action.Invoke();

                //if the transaction is successful, it will execute complete method. 
                //if failed, roll back.
                transaction.Complete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            transaction.Dispose();
        }
    }
}
