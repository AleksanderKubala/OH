using System.Collections;
using UnityEngine;

namespace Assets.UI
{
    public class UITooltip : UITextField
    {
        [SerializeField]
        private float fadeAwaitTime;
        private Coroutine _fadeTimer;
        private bool _followMouse;

        private void Awake()
        {
        }

        private void Update()
        {
            if(_followMouse)
            {
                transform.position = Input.mousePosition;
            }
        }

        public void DisplayText(string text, bool followMouse = true)
        {
            Text = text;
            _followMouse = followMouse;
            gameObject.SetActive(true);
            StopCoroutine(_fadeTimer);
        }

        public void Hide()
        {
            _fadeTimer = StartCoroutine(AwaitFade());
        }

        IEnumerator AwaitFade()
        {
            yield return new WaitForSecondsRealtime(fadeAwaitTime);
            gameObject.SetActive(false);
        }
    }
}
