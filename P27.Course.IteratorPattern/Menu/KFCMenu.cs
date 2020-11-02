using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P27.Course.IteratorPattern.Iterator;

namespace P27.Course.IteratorPattern.Menu
{
    public class KFCMenu
    {
        private Food[] _foodList = new Food[3];

        public KFCMenu()
        {
            this._foodList[0] = new Food()
            {
                Id=1,
                Name = "hamburger",
                Price = 15
            };

            this._foodList[1] = new Food()
            {
                Id = 2,
                Name = "Coke",
                Price = 10
            };

            this._foodList[2] = new Food()
            {
                Id = 3,
                Name = "Chips",
                Price = 8
            };

        }

        public Food[] GetFoods()
        {
            return this._foodList;
        }


        public Iiterator<Food> GetEnumerator()
        {
            KFCMenuIterator kfcIterator = new KFCMenuIterator(this);
            return kfcIterator;
        }





    }
}
