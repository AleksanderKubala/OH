using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.UI
{
    public abstract class UIDynamicContentPanel<TContent, TUIWithContent> : MonoBehaviour where TUIWithContent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _uiElementPrefab;
        [SerializeField]
        protected List<TUIWithContent> _uiElements;
        protected int _unusedUIElementsSubListIndex;

        protected int UnusedUIElementsCount => _uiElements.Count - _unusedUIElementsSubListIndex;
        protected abstract Transform UIElementParent { get; }

        public void RemoveContentFromUIElement(TContent content)
        {
            var referencingButton = GetUIElementWithContent(content);
            if (referencingButton != null)
            {
                ResetUIElement(referencingButton, default);
            }
        }

        public void RemoveContentFromUIElement(IEnumerable<TContent> contentCollection)
        {
            foreach (var content in contentCollection)
            {
                RemoveContentFromUIElement(content);
            }
        }

        public void SetContentInUIElement(TContent content)
        {
            if (_unusedUIElementsSubListIndex == _uiElements.Count)
            {
                CreateMultipleUIElements(1);
            }

            ResetUIElement(_uiElements[_unusedUIElementsSubListIndex], content);
            _unusedUIElementsSubListIndex++;
        }

        public void SetContentInUIElement(IEnumerable<TContent> contentCollection)
        {
            if (UnusedUIElementsCount < contentCollection.Count())
            {
                CreateMultipleUIElements(contentCollection.Count() - UnusedUIElementsCount);
            }

            foreach (var content in contentCollection)
            {
                ResetUIElement(_uiElements[_unusedUIElementsSubListIndex], content);
                _unusedUIElementsSubListIndex++;
            }
        }

        protected void CreateMultipleUIElements(int count)
        {
            if(count <= 0) { throw new ArgumentException(nameof(count) + "should be positive" ); }

            for (int i = 0; i < count; i++)
            {
                _uiElements.Add(CreateUIElement());
            }
        }

        protected virtual TUIWithContent CreateUIElement()
        {
            var newUIElement = Instantiate(_uiElementPrefab, Vector3.zero, Quaternion.identity, UIElementParent).GetComponent<TUIWithContent>();

            return newUIElement;
        }

        protected void RepositionUIElements(IComparer<TUIWithContent> comparer)
        {
            _uiElements.Sort(comparer);
            for(int i = 0; i < _uiElements.Count; i++)
            {
                _uiElements[i].transform.SetSiblingIndex(i);
            }
        }

        protected abstract void ResetUIElement(TUIWithContent uiElement, TContent content);
        protected abstract TUIWithContent GetUIElementWithContent(TContent content);
        protected abstract bool IsUIElementUnused(TUIWithContent uiElement);
    }
}
