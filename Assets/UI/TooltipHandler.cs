using System.Collections;
using Assets.Managers;
using Assets.UI.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UI
{
    public class TooltipHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private float hoverTime;
        private Coroutine displayTimer;

        [SerializeField]
        private TooltipDisplayedEvent TooltipDisplayed;

        public void OnPointerEnter(PointerEventData args)
        {
            displayTimer = StartCoroutine(AwaitDisplay());
        }

        public void OnPointerExit(PointerEventData args)
        {
            StopCoroutine(displayTimer);
            UIManager.Instance.GetTooltip().Hide();
        }

        IEnumerator AwaitDisplay()
        {
            yield return new WaitForSecondsRealtime(hoverTime);

            if (TooltipDisplayed != null)
            {
                var tooltipDisplayResponse = new TooltipDisplayedEventArgs();
                TooltipDisplayed.Invoke(tooltipDisplayResponse);

                if (!string.IsNullOrEmpty(tooltipDisplayResponse.TooltipText))
                {
                    var tooltip = UIManager.Instance.GetTooltip();
                    tooltip.DisplayText(tooltipDisplayResponse.TooltipText);
                }
            }
        }
    }
}
