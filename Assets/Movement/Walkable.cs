using Assets.Managers;
using Assets.OH;
using UnityEngine;

namespace Assets.Movement
{
    public class Walkable : MonoBehaviour
    {
        private void OnMouseUpAsButton()
        {
            if(Input.GetMouseButtonUp(0))
            {
                var mousePointRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if(Physics.Raycast(mousePointRay, out var hit, 150.0f, CommonValue.LayerMasks.Walkable, QueryTriggerInteraction.Ignore))
                {
                    GameManager.Player.SetDestinationFlag(hit.point);
                }
            }
        }
    }
}
