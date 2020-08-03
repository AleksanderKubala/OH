using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.UI
{
    public abstract class UIDynamicContentPanel<TContent, TUIWithContent> : MonoBehaviour where TUIWithContent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _uiElementPrefab;
        [SerializeField]
        protected List<TUIWithContent> _contentElements;
        protected int _unusedElementsSubListIndex;

        protected int UnusedElementsCount => _contentElements.Count - _unusedElementsSubListIndex;
        protected abstract Transform ContentsParent { get; }

        public void RemoveContentFromUIElement(TContent content)
        {
            var referencingButton = GetUIContentElementWithContent(content);
            if (referencingButton != null)
            {
                ResetContentElementButton(referencingButton, default);
            }
        }

        public void RemoveContentFromUIElement(IEnumerable<TContent> contentCollection)
        {
            foreach (var content in contentCollection)
            {
                RemoveContentFromUIElement(content);
            }
        }

        public void AppendUIContentElement(TContent content)
        {
            if (_unusedElementsSubListIndex == _contentElements.Count)
            {
                CreateMultipleUIContentElements(1);
            }

            ResetContentElementButton(_contentElements[_unusedElementsSubListIndex], content);
            _unusedElementsSubListIndex++;
        }

        public void AppendUIContentElement(IEnumerable<TContent> contentCollection)
        {
            if (UnusedElementsCount < contentCollection.Count())
            {
                CreateMultipleUIContentElements(contentCollection.Count() - UnusedElementsCount);
            }

            foreach (var content in contentCollection)
            {
                ResetContentElementButton(_contentElements[_unusedElementsSubListIndex], content);
                _unusedElementsSubListIndex++;
            }
        }

        protected void CreateMultipleUIContentElements(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _contentElements.Add(CreateContentUIElement());
            }
        }

        protected virtual TUIWithContent CreateContentUIElement()
        {
            var newUIElement = Instantiate(_uiElementPrefab, Vector3.zero, Quaternion.identity, ContentsParent).GetComponent<TUIWithContent>();

            return newUIElement;
        }

        protected void RepositionElements(IComparer<TUIWithContent> comparer)
        {
            _contentElements.Sort(comparer);
            for(int i = 0; i < _contentElements.Count; i++)
            {
                _contentElements[i].transform.SetSiblingIndex(i);
            }
        }

        protected abstract void ResetContentElementButton(TUIWithContent uiElement, TContent content);
        protected abstract TUIWithContent GetUIContentElementWithContent(TContent content);
        protected abstract bool IsUIElementUnused(TUIWithContent uiElement);
    }
}
