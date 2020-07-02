using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.ResponsibilityChain
{
    public class Manager: AbstractAuditor
    {
        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 24)
            {
                context.AuditResult = true;
                context.AuditRemark = "Approve !";
            }
            else
            {
                base.AuditNext(context);
            }
        }





    }
}
