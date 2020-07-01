using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.ResponsibilityChain
{
    public abstract class AbstractAuditor
    {
        public string Name { get; set; }

        public abstract void Audit(ApplyContext context);







    }
}
