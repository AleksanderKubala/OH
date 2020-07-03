using Assets.Items;
using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textRender;
    [SerializeField]
    private RectTransform textTransform;

    public string Text
    {
        get
        {
            return textRender.text;
        }
        set
        {
            textRender.autoSizeTextContainer = true;
            textRender.text = value ?? "";
        }
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
