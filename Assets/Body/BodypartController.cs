using System;
using System.Collections;
using UnityEngine;
using Assets.OH.Body.Data;
using OHLogic.Body;

namespace Assets.OH.Body
{
    [Serializable]
    public abstract class BodypartController : MonoBehaviour
    {
        [SerializeField]
        private MeshRenderer _meshRenderer;
        [SerializeField]
        private BodypartData _bodypartData;
        private Bodypart bodypart;
    
        //public EnemyAttackHit EnemyAttackHit;

        public BodypartData BodypartData => _bodypartData;

        protected virtual void Awake()
        {
            bodypart = _bodypartData.CreateBodypartInstance();
            bodypart.BodypartDamageChanged += OnBodypartDamageChanged;
        }

        private void OnBodypartDamageChanged(object sender, float e)
        {
            if(e > 0.0f)
            {
                StartCoroutine(BodypartHurt());
            }
        }

        private IEnumerator BodypartHurt()
        {
            if (_meshRenderer)
            {
                Color color = _meshRenderer.material.color;
                _meshRenderer.material.SetColor("_Color", Color.red);
                yield return new WaitForSeconds(0.2f);
                _meshRenderer.material.SetColor("_Color", color);
            }
        }
    }
}
