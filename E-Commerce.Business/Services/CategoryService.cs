using E_Commerce.Business.Services.Interface;
using E_Commerce.Core.Model;
using E_Commerce.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services
{
    public class CategoryService 
    {
        AppDbContext _db = new AppDbContext();

        public IEnumerable<Category> GetAll()
        {
            var data = _db.Categories.ToList();
            return data;
        }
        public void Create(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category entity)
        {
            throw new NotImplementedException();
        }

    

       
      
    }
}
