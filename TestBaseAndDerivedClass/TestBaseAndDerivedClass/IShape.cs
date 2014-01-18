using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App
{
    public interface IShape
    {
        decimal Length { get; set; }
        decimal Width { get; set; }
        decimal Area();
    }
}
