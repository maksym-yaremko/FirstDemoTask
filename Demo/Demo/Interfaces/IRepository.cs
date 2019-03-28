using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetList(); 
        Task<T> GetById(int id); 
        void Create(T item); 
        void Update(T item); 
        void Delete(int id); 
    }
}
