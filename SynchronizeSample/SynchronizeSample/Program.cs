using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SynchronizeSample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class Synchronization 
    {
        private readonly object obj = new object();
        private Person person;

        /// <summary>
        /// Single Lock
        /// </summary>
        public void SingleLock()
        {
            lock (obj) 
            {
                if (person == null) 
                {
                    person = new Person();
                }
            }
        }

        public void DoubleLock()
        {
            if (person == null) 
            {
                lock (obj) 
                {
                    if (person == null) 
                    {
                        person = new Person();
                    }
                }
            }
        }
    }
}
