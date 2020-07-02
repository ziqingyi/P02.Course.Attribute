using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.ResponsibilityChain
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplyContext context = new ApplyContext()
            {
                Id = 506,
                Name = "yoyo",
                Hour = 100,
                Description = "join icc meeting",
                AuditResult = false,
                AuditRemark = ""
            };


            AbstractAuditor auditor = AuditorBuilder.Build();

            auditor.Audit(context);

            Console.WriteLine(context.AuditResult+ "  " context.AuditRemark);

        }
    }
}
