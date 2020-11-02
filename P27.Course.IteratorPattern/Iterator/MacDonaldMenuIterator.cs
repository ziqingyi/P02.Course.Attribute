using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P27.Course.IteratorPattern.Menu;

namespace P27.Course.IteratorPattern.Iterator
{
    public class MacDonaldMenuIterator :Iiterator<Food>
    {
        private List<Food> _foodList = null;

        public MacDonaldMenuIterator(MacDonaldMenu macDonaldMenu)
        {
            this._foodList = macDonaldMenu.Getfoods();
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
            bool hasSomeItemsLeft = this._foodList.Count > ++this._currentIndex;
            return hasSomeItemsLeft;
        }

        public void Reset()
        {
            this._currentIndex = -1;
        }
    }
}
