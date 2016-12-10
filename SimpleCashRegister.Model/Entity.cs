using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCashRegister.Model
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        protected Entity(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("Identifier cannot be of the default type value.");
            }
            Id = id;
        }

        public TId Id { get; set; }

		public override bool Equals(object obj)
		{
			var entity = obj as Entity<TId>;
			if (entity != null) return Equals(entity);
			return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity<TId> other)
		{
			if (other == null) return false;
			return Id.Equals(other.Id);
		}
    }
}
