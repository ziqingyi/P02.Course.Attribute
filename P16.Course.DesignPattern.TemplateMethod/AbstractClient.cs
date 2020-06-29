using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.TemplateMethod
{
    public abstract class AbstractClient
    {
        public void Query(int id, string name, string password)
        {
            if (this.CheckUser(id, password))
            {
                double balance = this.QueryBalance(id);
                double interest = this.CalculateInterest(balance);
            }
            else
            {
                Console.WriteLine("wrong log in");
            }
        }

        public bool CheckUser(int id, string password)
        {
            return DateTime.Now < DateTime.Now.AddDays(1);
        }

        public double QueryBalance(int id)
        {
            return new Random().Next(10000,1000000);
        }

        // abstract method, don't have implementation, means every derived class must have 
        public abstract double CalculateInterest(double balance);

        //default implementation, so use virtual method, derived class can have different implementation. 
        public virtual void Show(string name, double balance, double interest)
        {
            Console.WriteLine("Hi {0}, your balance is {1}, interest is {2} ", name,balance,interest);
        }


    }
}
