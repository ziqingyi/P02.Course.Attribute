using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P27.Course.IteratorPattern.Menu
{
    public class MacDonaldMenu
    {
        private List<Food> _foodList = new List<Food>();

        public MacDonaldMenu()
        {
            this._foodList.Add(new Food()
            {
                Id=1,
                Name ="chicken roll",
                Price = 15
            });

            this._foodList.Add(new Food()
            {
                Id = 2,
                Name = "CheeseBurger",
                Price = 10
            });

            this._foodList.Add(new Food()
            {
                Id =3,
                Name = "large chips",
                Price = 5
            });
        }

        public List<Food> Getfoods()
        {
            return this._foodList;
        }


        public Iiterator<Food> GetEnumerator()
        {



        }


    }
}
