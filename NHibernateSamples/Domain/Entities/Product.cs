﻿
namespace Domain
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string ProductType { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual bool Discontinued { get; set; }
    }
}