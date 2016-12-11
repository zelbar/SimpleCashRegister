using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCashRegister.DataAccessLayer.Persisters;
using SimpleCashRegister.Model;
using SimpleCashRegister.Exceptions;

namespace SimpleCashRegister.DataAccessLayer.Repositories
{
    public class Repository<TId, TEntity> : IRepository<TId, TEntity>
        where TEntity : Entity<TId>
    {
        public Repository(XmlPersister<TEntity> persister)
        {
            _persister = persister;
        }

        protected readonly XmlPersister<TEntity> _persister;

        public virtual TId Add(TEntity item)
        {
            _persister.Load();
            var list = _persister.GetList();
            var existing = list.FirstOrDefault(x => Equals(x.Id, item.Id));

            if (existing != null)
            {
                throw new EntityAlreadyExistsException();
            }

            list.Add(item);
            _persister.Save();
            return item.Id;
        }

        public virtual void Delete(TId id)
        {
            _persister.Load();
            var list = _persister.GetList();
            var itemToRemove = list.FirstOrDefault(x => Equals(x.Id, id));

            if (itemToRemove == null)
            {
                throw new EntityNotFoundException();
            }

            list.Remove(itemToRemove);
            _persister.Save();
        }

        public virtual void Edit(TEntity item)
        {
            _persister.Load();
            var list = _persister.GetList();
            var itemToRemove = list.FirstOrDefault(x => Equals(x.Id, item.Id));

            if (itemToRemove == null)
            {
                throw new EntityNotFoundException();
            }

            list.Remove(itemToRemove);
            list.Add(item);
            _persister.Save();
        }

        public virtual TEntity GetById(TId id)
        {
            _persister.Load();
            var list = _persister.GetList();
            var itemToGet = list.FirstOrDefault(x => Equals(x.Id, id));

            if (itemToGet == null)
            {
                throw new EntityNotFoundException();
            }

            return itemToGet;
        }

        public virtual List<TEntity> GetAll()
        {
            _persister.Load();
            var list = _persister.GetList();
            return list;
        }
    }
}
