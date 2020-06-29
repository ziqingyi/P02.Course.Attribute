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
        public string name = "";
        public double balance = 0;
        public double interest = 0;

        public void Query(int id, string nameIn, string password)
        {
            this.name = nameIn;
            if (this.CheckUser(id, password))
            {
                 balance = this.QueryBalance(id);
                 interest = this.CalculateInterest(balance);
                 this.Show();
                 this.Normal();//always call this class's method
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
        public virtual void Show()
        {
            Console.WriteLine("Hi {0}, your balance is {1}, interest is {2} ", this.name,this.balance,this.interest);
        }

        public void Normal()
        {
            Console.WriteLine("abstract normal");
        }

    }
}
