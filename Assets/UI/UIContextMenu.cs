using System.Collections.Generic;
using System.Linq;
using Assets.UI;
using Assets.UI.Events;
using UnityEngine;

public class UIContextMenu : MonoBehaviour
{
    [SerializeField]
    private UIContextAction _cancel;
    [SerializeField]
    private RectTransform _rectTransform;
    private LinkedList<UIContextAction> _menuActions;

    private void Awake()
    {
        _menuActions = new LinkedList<UIContextAction>();
    }

    private void Start()
    {
        _cancel.gameObject.SetActive(true);
        _cancel.transform.SetAsLastSibling();
    }

    public void SetContextAction(IContextActionSubscriber contextActionSubscription)
    {
        var contextAction = ContextActionPool.Instance.GetObjectFromPool();
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
            ContextActionPool.Instance.ReturnObject(contextAction);
        }

        _menuActions.Clear();
        gameObject.SetActive(false);
    }
}
