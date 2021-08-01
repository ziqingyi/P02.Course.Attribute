using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.PersonTest
{

    public class PeopleYield : IEnumerable
    {
        private readonly Person[] _people;
        public PeopleYield(Person[] pArray)
        {
            //build a array
            _people = new Person[pArray.Length];
            for (var i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        //implement   IEnumerable interface,  GetEnumerator
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _people.Length; i++)
            {
                yield return _people[i];
            }
        }
    }


    //construct People for simulating List<Person>
    public class People : IEnumerable
    {
        private readonly Person[] _people;
        public People(Person[] pArray)
        {
            //build a array
            _people = new Person[pArray.Length];
            for (var i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }

        //implement   IEnumerable interface,  GetEnumerator
        public IEnumerator GetEnumerator()
        {
            return new PeopleEnumerator(_people);
        }
    }


    public class PeopleEnumerator : IEnumerator
    {
        public Person[] People;
        private int _position = -1;//current position

        object IEnumerator.Current
        {
            get
            {
                try
                {
                    return People[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public PeopleEnumerator(Person[] people)
        {
            People = people;
        }

        public bool MoveNext()
        {
            _position++;
            return (_position < People.Length);
        }

        public void Reset()
        {
            _position = -1;
        }
    }






}
