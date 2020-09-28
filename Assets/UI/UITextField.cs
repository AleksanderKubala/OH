using TMPro;
using UnityEngine;

public class UITextField : MonoBehaviour
{
    [SerializeField]
    private TMP_Text textRender;
    [SerializeField]
    protected RectTransform textTransform;

    public string Text
    {
        get
        {
            return textRender.text;
        }
        set
        {
            textRender.text = value ?? "";
        }
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
