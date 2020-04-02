using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate
{
    public class EventStandard
    {
        public static void Show()
        {
            // subscribe
            IphoneX x10 = new IphoneX()
            {
                Id = 123,
                tag = "aus version",
                Price = 6666
            };

            // connection between subscriber and publisher
            x10.DiscountHandler += new Student().Buy;
            x10.DiscountHandler += new Tencent().promote;

            x10.Price = 5000;
        }

        // subscriber
        public class Student
        {
            public void Buy(object sender, EventArgs e)
            {
                IphoneX phone = (IphoneX) sender;
                Console.WriteLine($"This is {phone.tag} iphone");

                XEventArgs args = (XEventArgs) e;
                Console.WriteLine($"original price {args.oPrice}");
                Console.WriteLine($" price now {args.NewPrice}");

            }
        }
        //publi
        public class Tencent
        {
            public void promote(object sender, EventArgs e)
            {
                IphoneX phone = (IphoneX)sender;
                Console.WriteLine($"This is {phone.tag} iphone");

                XEventArgs args = (XEventArgs)e;
                Console.WriteLine($"original price {args.oPrice}");
                Console.WriteLine($" price now {args.NewPrice}");
                Console.WriteLine(" please notice ");

            }
        }


        public class XEventArgs : EventArgs
        {
            public int oPrice { get; set; }
            public int NewPrice { get; set; }
        }

        public class IphoneX
        {
            public int Id { get; set; }
            public string tag { get; set; }

            private int _price;

            public int Price 
            {
                get { return this._price; }
                set
                {
                    if (value < this._price)
                    {
                        this.DiscountHandler?.Invoke(this, new XEventArgs()
                        {
                            oPrice = this._price,
                            NewPrice = value
                        });
                        this._price = value;
                    }

                }
            }
            public event EventHandler DiscountHandler;

        }

    }
}
