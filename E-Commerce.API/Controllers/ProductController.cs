using E_Commerce.Core.Model;
using E_Commerce.Core.Model.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace E_Commerce.API.Controllers
{
    public class ProductController : ApiController
    {
        AppDbContext db = new AppDbContext();
        public List<Product> Get()
        {
            var data = db.Products.Where(x => x.IsActive == true).ToList();
            return data;
        }
    }
}
