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
        private AbstractAuditor _nextAuditor = null;

        public void SetNext(AbstractAuditor auditor)
        {
            this._nextAuditor = auditor;
        }

        protected void AuditNext(ApplyContext context)
        {
            if (this._nextAuditor != null)
            {
                this._nextAuditor.Audit(context);
            }
            else
            {
                context.AuditResult = false;
                context.AuditRemark = "Not Approve!";
            }

        }





    }
}
