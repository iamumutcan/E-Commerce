using E_Commerce.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Services.Interface
{
    public interface IGenericService<T> where T : class
    {
        t GetById(int id);
        IEnumerable<T> GetAllProducts();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
