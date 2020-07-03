using Assets.Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Movement
{
    public class Walkable : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                GameManager.Player.Walk(eventData.pointerCurrentRaycast.worldPosition);
            }
        }
    }
}
