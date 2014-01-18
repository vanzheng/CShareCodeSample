using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public abstract class Shape : IShape
    {

        private string _shapeName;

        protected Shape() 
        {
            
        }

        protected Shape(string shapeName) 
        {
            this._shapeName = shapeName;
        }

        public virtual string ShapeName 
        {
            get { return _shapeName; }
            set { _shapeName = value; }
        }

        public abstract decimal Length
        {
            get;
            set;
        }

        public abstract decimal Width
        {
            get;
            set;
        }

        public virtual decimal Area() 
        {
            return Length * Width;
        }
    }
}
