using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGenericInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People(
                new Person("张三", 20, new DateTime(1991, 1, 2)),
                new Person("李四", 22, new DateTime(1989, 2, 3)),
                new Person("王五", 25, new DateTime(1986, 3, 10))
                );

            Person person6 = new Person("赵六", 26, new DateTime(1985, 3, 12));
            people.Add(person6);
            Person[] persons = new Person[5];
            people.CopyTo(persons, 0);

            foreach (Person person in people) 
            {
                Console.WriteLine(string.Format("name: {0}  age: {1}  birthday: {2}", person.Name, person.Age, person.BirthDay.ToString()));
            }
            Console.WriteLine("===============Person Array Start============");

            for (int i = 0; i <= 1; i++) 
            {
                Console.WriteLine(string.Format("name: {0}  age: {1}  birthday: {2}", persons[i].Name, persons[i].Age, persons[i].BirthDay.ToString()));
            }
            //foreach (Person person in persons)
            //{
            //    Console.WriteLine(string.Format("name: {0}  age: {1}  birthday: {2}", person.Name, person.Age, person.BirthDay.ToString()));
            //}

            Console.WriteLine("===============Person Array End============");

            //“赵六”
            Console.WriteLine("========a person start=======");
            Person person_6 = people["赵六"];
            Console.WriteLine(string.Format("name: {0}  age: {1}  birthday: {2}", person_6.Name, person_6.Age, person_6.BirthDay.ToString()));
            Console.WriteLine("========a person end=======");
            Console.ReadKey();
        }
    }

    public class Person
    {
        public Person() 
        {
        
        }

        public Person(string name, int age, DateTime birthDay) 
        {
            this.Name = name;
            this.Age = age;
            this.BirthDay = birthDay;
        }

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public DateTime BirthDay
        {
            get;
            set;
        }
    }

    public class People : IList, ICollection, IEnumerable
    {
        private IList<Person> _persons;

        public People() 
        {
            this._persons = new List<Person>();
        }

        public People(params Person[] persons) 
        {
            this._persons = new List<Person>();
            if (persons != null) 
            {
                foreach (Person person in persons) 
                {
                    this.Add(person);
                }
            }
        }

        int IList.Add(object value) 
        {
            return ((IList)this).Add(value);
        }

        public void Add(Person person) 
        {
            this._persons.Add(person);
        }

        public IEnumerator GetEnumerator() 
        {
            return this._persons.GetEnumerator();
        }

        public int IndexOf(object value) 
        {
            if (value != null) 
            {
                if (this._persons == null || this._persons.Count == 0)
                {
                    return -1;
                }
                else 
                {
                    for (int i = 0; i < this._persons.Count; i++) 
                    {
                        if (this._persons[i] == value)
                            return i;
                    }
                }
            }
            return -1;
        }

        public int IndexOf(Person value) 
        {
            return IndexOf(value);
        }

        public int IndexOf(string name) 
        {
            return IndexOf(this._persons, name);
        }

        private int IndexOf(IList<Person> persons, string name) 
        {
            if (persons == null || persons.Count == 0)
                return -1;

            int i = 0;
            bool existed = false;
            foreach (Person person in persons) 
            {
                if (person.Name == name) 
                {
                    existed = true;
                    break;
                }
                i++;
            }
            if (existed)
                return i;
            else
                return -1;
        }


        public bool IsFixedSize 
        {
            get 
            {
                return ((IList)this._persons).IsFixedSize;
            }
        }

        public bool IsReadOnly 
        {
            get 
            {
                return ((IList)this._persons).IsReadOnly;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return ((IList)this)[index];
            }
            set
            {
                ((IList)this)[index] = value;
            }
        }

        public Person this[int index]
        {
            get 
            {
                return this._persons[index];
            }
            set 
            {
                this._persons[index] = value;
            }
        }

        public Person this[string name] 
        {
            get 
            {
                int pos = IndexOf(name);
                return this._persons[pos];
            }
            set 
            {
                int pos = IndexOf(name);
                if (pos == -1)
                    throw new Exception("不存在");
                Replace(pos, this[pos]);
            }
        }

        private void Replace(int index, Person newPerson) 
        {
            this._persons[index] = newPerson;
        }

        public void Clear() 
        {
            this._persons.Clear();
        }

        void IList.Remove(object value) 
        {
            ((IList)this).Remove(value);
        }

        public void Remove(Person person) 
        {
            this._persons.Remove(person);
        }

        public void RemoveAt(int index) 
        {
            this._persons.RemoveAt(index);
        }

        bool IList.Contains(object value) 
        {
            return ((IList)this).Contains(value);
        }

        public bool Contains(Person person) 
        {
            return this._persons.Contains(person);
        }

        void IList.Insert(int index, object value) 
        {
            ((IList)this).Insert(index, value);
        }

        public void Insert(int index, Person person) 
        {
            this._persons.Insert(index, person);
        }

        //public Person this[string name] 
        //{
        //    get 
        //    {
                
        //    }
        //}

        public int Count 
        {
            get 
            {
                if (this._persons == null)
                    return 0;
                return this._persons.Count;
            }
        }

        public bool IsSynchronized 
        {
            get
            {
                return ((ICollection)this._persons).IsSynchronized;
            }
        }

        public object SyncRoot 
        {
            get 
            {
                return ((ICollection)this._persons).SyncRoot;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            ((ICollection)this).CopyTo(array, index);
        }

        public void CopyTo(Person[] persons, int index) 
        {
            //((ICollection)this).CopyTo(persons, index);
            this._persons.CopyTo(persons, index);
        }
    }
}
