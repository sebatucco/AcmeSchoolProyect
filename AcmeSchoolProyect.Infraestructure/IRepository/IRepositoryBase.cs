using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        Guid Add(T entity);
        IEnumerable<T> GetAll();
        void Remove(T entity);
    }
}
