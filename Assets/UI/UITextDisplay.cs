using UnityEngine;

namespace Assets.UI
{
    public class UITextDisplay : MonoBehaviour
    {
        [SerializeField]
        private string _displayedText;

        private UIText _uiText;


        public void AcquireTextElement()
        {
            _uiText = UITextPool.Instance.GetObjectFromPool();
            _uiText.transform.forward = Camera.main.transform.forward;
            _uiText.transform.position = transform.position;
            _uiText.Text = _displayedText;
        }

        public void ReleaseTextElement()
        {
            UITextPool.Instance.ReturnObject(_uiText);
            _uiText = null;
        }

        public void Show()
        {
            _uiText.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _uiText.gameObject.SetActive(false);
        }
    }
}
