using System.Collections.Generic;
using System.Linq;
using Assets.Common;
using Assets.Managers;
using UnityEngine;

namespace Assets.GameEntity
{
    [CreateAssetMenu(fileName = "Game Entity Type", menuName = "Game Entities/Entity Type")]
    public class GameEntityType : ScriptableObject, IType<GameEntityType>
    {
        [SerializeField]
        private List<GameEntityType> _directParentTypes;

        public GameEntityType()
        {
            GameEntityTypesManager.RegisterType(this);
        }

        public void Init()
        {
            if(_directParentTypes.Any())
            {
                GameEntityTypesManager.LinkToParents(this, new HashSet<GameEntityType>(_directParentTypes));
            }
        }

        public bool BelongsToType(GameEntityType type)
        {
            var belongsToType = this.Equals(type) || GameEntityTypesManager.TypeHasParent(this, type);

            return belongsToType;
        }

        //public bool Equals(GameEntityType other)
        //{
        //    if (other != null)
        //    {
        //        if (ReferenceEquals(this, other) || (Name == other.Name))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        //public override bool Equals(object obj)
        //{
        //    var casted = obj as GameEntityType;

        //    return Equals(casted);
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}
    }
}
