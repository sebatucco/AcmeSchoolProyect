using AcmeSchoolProyect.Core.Entites.BaseEntity;
using AcmeSchoolProyect.Infraestructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeSchoolProyect.Infraestructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntity
    {
        protected readonly List<T> _entities;
        public RepositoryBase()
        {
            _entities = new List<T>();
        }

        public Guid Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            _entities.Add(entity);
            return entity.Id;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }
        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        protected virtual int GetEntityId(T entity)
        {
            var property = entity.GetType().GetProperty("Id");
            return (int)property.GetValue(entity);
        }
    }
}
