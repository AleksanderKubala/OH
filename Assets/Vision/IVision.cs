using UnityEngine;

namespace Assets.OH.Vision
{
    public interface IVision
    {
        bool CanSee(GameObject target, Ray ray);
    }
}
