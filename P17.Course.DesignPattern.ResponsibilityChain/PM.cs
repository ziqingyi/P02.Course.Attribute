using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.ResponsibilityChain
{
    public class PM : AbstractAuditor
    {


        public override void Audit(ApplyContext context)
        {
            Console.WriteLine($"This is {this.GetType().Name} {this.Name} Audit");
            if (context.Hour <= 8)
            {
                context.AuditResult = true;
                context.AuditRemark = "approve";
            }
            else
            {
                base.AuditNext(context);
            }
        }


    }
}
