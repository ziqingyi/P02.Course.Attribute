using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P17.Course.DesignPattern.ResponsibilityChain
{
    public class AuditorBuilder
    {
        //can also use reflection + config files
        //factory can be used to simplify below as well.
        public static AbstractAuditor Build()
        {

            AbstractAuditor pm = new PM()
            {
                Name = "pm1"
            };
            AbstractAuditor charge = new Charge()
            {
                Name = "charge1"
            };
            AbstractAuditor manager = new Manager()
            {
                Name = "manager1"
            };
            AbstractAuditor director = new Director()
            {
                Name = "director1"
            };
            AbstractAuditor ceo = new CEO()
            {
                Name = "ceo1"
            };
            AbstractAuditor chairman = new ChairMan()
            {
                Name =  "chairman1"
            };


            pm.SetNext(charge);
            charge.SetNext(manager);
            manager.SetNext(director);
            director.SetNext(ceo);
            ceo.SetNext(chairman);

            return pm;
        }













    }
}
