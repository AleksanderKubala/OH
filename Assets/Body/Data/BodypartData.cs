using UnityEngine;
using OHLogic.Data;
using OHLogic.Body;

namespace Assets.OH.Body.Data
{
    public abstract class BodypartData : ScriptableObject, IBodypartData
    {
        [SerializeField]
        private float _maximumHealth;

        public abstract BodypartType BodypartType { get; }
        public float MaximumHealth => _maximumHealth;

        public Bodypart CreateBodypartInstance()
        {
            throw new System.NotImplementedException();
        }
    }

}