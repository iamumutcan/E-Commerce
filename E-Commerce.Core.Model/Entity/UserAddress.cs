namespace E_Commerce.Core.Model.Entity
{
    public class UserAddress : EntityBase
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string BuildingNumber { get; set; }

        public bool IsActive { get; set; }

    }
}
