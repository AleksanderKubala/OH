using System;
using OHLogic.Actions;
using OHLogic.Actions.Data;
using UnityEngine;

namespace Assets.Combat
{
    public abstract class CombatAction<TData> : IActionWithData<TData> where TData : ActionData
    {
        protected float lastAttemptSpeed;
        protected float summedAttemptsSpeed;
        protected float lastAttemptQuality;
        protected float summedAttemptQuality;
        protected int attemptsCount;
        public CombatAction()
        {
            lastAttemptQuality = 0.0f;
            lastAttemptSpeed = 0.0f;
            summedAttemptQuality = 0.0f;
            summedAttemptsSpeed = 0.0f;
            attemptsCount = 0;
        }

        public event EventHandler<IAction> ActionFinished;

        public bool IsAvailable => !FinishTime.HasValue;
        public float? FinishTime { get; private set; }
        public float AverageTime => summedAttemptsSpeed / attemptsCount;
        public float? Quality { get; private set; }
        public float AverageQuality { get; private set; }
        public abstract TData ActionData { get;  protected set; }

        public virtual void Attempt()
        {
            lastAttemptSpeed = GenerateDeltaTime();
            FinishTime = Time.time + lastAttemptSpeed;
            Quality = lastAttemptQuality = GenerateAttemptQuality();

            summedAttemptsSpeed += lastAttemptSpeed;
            summedAttemptQuality += lastAttemptQuality;
            attemptsCount++;
        }

        public virtual void Cease()
        {
            if (FinishTime.HasValue && Quality.HasValue)
            {
                summedAttemptsSpeed -= lastAttemptSpeed;
                summedAttemptQuality -= lastAttemptQuality;
                attemptsCount--;
            }

            FinishTime = null;
            Quality = null;
        }

        public virtual void Finish()
        {
            FinishTime = null;
            ActionFinished?.Invoke(this, this);
        }

        protected float GenerateDeltaTime()
        {
            return ActionData.ActionSpeed + UnityEngine.Random.Range(0.2f, 0.5f);
        }

        protected float GenerateAttemptQuality()
        {
            return  UnityEngine.Random.value;
        } 
    }
}
