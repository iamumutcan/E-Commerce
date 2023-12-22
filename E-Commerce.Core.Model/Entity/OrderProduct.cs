﻿namespace E_Commerce.Core.Model.Entity
{
    public class OrderProduct : EntityBase
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
