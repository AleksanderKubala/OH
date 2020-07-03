using System;
using System.Collections;
using System.Collections.Generic;
using Assets.UI;
using Boo.Lang.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ContextMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _interactionButtonPrefab;
    [SerializeField]
    private List<ContextMenuOption> _interactionButtons;
    private int _optionIndex;

    private void Awake()
    {
        _optionIndex = 0;
        gameObject.SetActive(false);
    }

    public ContextMenuOption GetUnassignedContextOption()
    {
        ContextMenuOption contextOption;
        if((_optionIndex + 1) >= _interactionButtons.Count)
        {
            contextOption = Instantiate(_interactionButtonPrefab, gameObject.transform, false).GetComponent<ContextMenuOption>();
            //TODO: Replace with proper exception
            if(contextOption == null) { throw new RuntimeException("GameObject instantiation exception: corrupted gameObject: ContextMenuOption - missing ContextMenuOption script"); }
            _interactionButtons.Add(contextOption);
        }
        else
        {
            contextOption = _interactionButtons[_optionIndex];
        }

        return contextOption;
    }

    public void Hide()
    {
        for(int i = _optionIndex; i >= 0; i--)
        {
            var contextOption = _interactionButtons[i];
            contextOption.ContextOptionSelected.RemoveAllListeners();
            contextOption.gameObject.SetActive(false);
        }

        _optionIndex = 0;
        gameObject.SetActive(false);
    }

    public void Display(Vector3 screenPointLeftTop)
    {
        for(int i = 0; i < _optionIndex; i++)
        {
            _interactionButtons[i].gameObject.SetActive(true);
        }

        gameObject.transform.position = screenPointLeftTop;
        gameObject.SetActive(true);
    }
}
