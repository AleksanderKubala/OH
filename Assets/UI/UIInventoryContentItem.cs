using Assets.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    //TODO: Reconsider inventory, inventory UI and items implementation. Eight now interactions are attached to gameObjects and dropping inventory contents (or any other interaction) from inventory UI  is impossible.
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

        private void Start()
        {
            Item = _item;
        }
    }
}
