using System;
using System.Collections.Generic;
using System.Linq;
using Assets.GameEntity;

namespace Assets.Body
{
    public class GameEntityBody : IGameEntityBody
    {
        protected HashSet<Bodypart> bodyparts;
        protected float totalHealth;
        protected float totalDamage;

        public GameEntityBody(IGameEntity owningGameEntity)
        {
            OwningGameEntity  = owningGameEntity ?? throw new ArgumentNullException(nameof(owningGameEntity));
            bodyparts = new HashSet<Bodypart>();
        }

        public event EventHandler<Bodypart> BodypartAdded;
        public event EventHandler<Bodypart> BodypartRemoved;

        public IGameEntity OwningGameEntity { get; protected set; }
        public float CurrentHealth => totalHealth - totalDamage;
        public float OverallCondition => CurrentHealth / totalHealth;

        public virtual void AddBodypart(Bodypart bodypart)
        {
            if(bodypart == null)
            {
                throw new ArgumentNullException(nameof(bodypart));
            }

            if (bodyparts.Add(bodypart))
            {
                BodypartAdded?.Invoke(this, bodypart);
            }
        }

        public virtual void RemoveBodypart(Bodypart bodypart)
        {
            if(bodyparts.Remove(bodypart))
            {
                BodypartRemoved?.Invoke(this, bodypart);
            }
        }

        public IEnumerable<Bodypart> GetBodyparts()
        {
            var retrievedBodyparts = bodyparts.Select(x => x);

            return retrievedBodyparts;
        }

        public IEnumerable<Bodypart> GetBodyparts(Func<Bodypart, bool> predicate)
        {
            var retrievedBodyparts = bodyparts.Where(predicate);
            
            return retrievedBodyparts; 
        }

        protected virtual void OnBodypartDamageChanged(object sender, float amount)
        {
            totalDamage += amount;
        }
    }
}


