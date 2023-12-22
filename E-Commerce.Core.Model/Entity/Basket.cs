namespace E_Commerce.Core.Model.Entity
{
    public class Basket : EntityBase
    {
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
