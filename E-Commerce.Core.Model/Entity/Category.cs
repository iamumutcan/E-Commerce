namespace E_Commerce.Core.Model.Entity
{
    public class Category : EntityBase
    {
        public int ParentID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
