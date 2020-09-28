using Assets.Data;
using UnityEngine;

namespace Assets.Body.Data
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