using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Model.Entity
{
    public class Category:EntityBase
    {
        public int ParentID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
