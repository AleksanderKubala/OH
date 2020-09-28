using UnityEngine;

namespace Assets.Vision
{
    public interface IVision
    {
        bool CanSee(GameObject target, Ray ray);
    }
}
