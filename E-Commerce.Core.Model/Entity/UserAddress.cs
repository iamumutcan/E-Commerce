namespace E_Commerce.Core.Model.Entity
{
    public class UserAddress : EntityBase
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}
