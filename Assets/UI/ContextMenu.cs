using System.Collections.Generic;
using Assets.UI;
using Boo.Lang.Runtime;
using UnityEngine;

public class ContextMenu : MonoBehaviour
{
    [SerializeField]
    private ContextMenuAction _cancel;
    [SerializeField]
    private RectTransform _rectTransform;

    private LinkedList<ContextMenuAction> _menuActions;

    private void Awake()
    {
        _menuActions = new LinkedList<ContextMenuAction>();
    }

    private void Start()
    {
        _cancel.gameObject.SetActive(true);
        _cancel.transform.SetAsLastSibling();
    }

    public void AddContextAction(ContextActionSubscription contextActionSubscription)
    {
        var contextAction = ContextMenuActionPool.Instance.GetObjectFromPool();
        contextAction.Subscription = contextActionSubscription;
        contextAction.gameObject.SetActive(true);
        _menuActions.AddLast(contextAction);
    }

    public void Display(Vector3 screenPointLeftTop)
    {
        screenPointLeftTop.x += _rectTransform.rect.width / 2;
        screenPointLeftTop.y -= _rectTransform.rect.height / 2;

        gameObject.transform.position = screenPointLeftTop;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        foreach(var contextAction in _menuActions)
        {
            ContextMenuActionPool.Instance.ReturnObject(contextAction);
        }

        _menuActions.Clear();
        gameObject.SetActive(false);
    }
}
