using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P27.Course.IteratorPattern.Menu;

namespace P27.Course.IteratorPattern.Iterator
{
    public class KFCMenuIterator : Iiterator<Food>
    {
        private Food[] _foodList = null;

        public KFCMenuIterator(KFCMenu kfcMenu)
        {
            this._foodList = kfcMenu.GetFoods();
        }

        private int _currentIndex = -1;

        public Food Current
        {
            get
            {
                Food fd = this._foodList[_currentIndex];
                return fd;
            }
        }


        public bool MoveNext()
        {
            bool re = this._foodList.Length > ++this._currentIndex;
            return re;
        }

        public void Reset()
        {
            this._currentIndex = -1;
        }


    }
}
