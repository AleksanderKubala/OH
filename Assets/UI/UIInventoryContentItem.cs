using OHLogic.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class UIInventoryContentItem : MonoBehaviour
    {
        [SerializeField]
        private Text _textField;
        private IItem _item;

        public IItem Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                if(_item == null)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
        }

        private void Start()
        {
            Item = _item;
        }

        public string Label
        {
            get
            {
                return _textField.text;
            }
            set
            {
                _textField.text = value ?? "";
            }
        }
    }
}
