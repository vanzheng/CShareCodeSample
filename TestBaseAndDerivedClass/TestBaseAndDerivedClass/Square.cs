using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public class Square : Shape
    {        
        public Square(string shapeName) : base(shapeName)
        {
            this.ShapeName = "子类" + shapeName;
        }

        public override string ShapeName
        {
            get
            {
                return base.ShapeName;
            }
            set
            {
                base.ShapeName = value;
            }
        }

        public override decimal Length
        {
            get;
            set;
        }

        public override decimal Width
        {
            get;
            set;
        }

        public override decimal Area()
        {
            return base.Area()+1;
        }
    }
}
