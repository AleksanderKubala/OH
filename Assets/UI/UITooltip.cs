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
                UpdatePosition();
            }
        }

        public void DisplayText(string text, bool followMouse = true)
        {
            Text = text;
            _followMouse = followMouse;
            UpdatePosition();
            gameObject.SetActive(true);
            if(_fadeTimer != null)
            {
                StopCoroutine(_fadeTimer);
            }
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

        private void UpdatePosition()
        {
            transform.position = Input.mousePosition + Vector3.down * 40;
        }
    }
}
