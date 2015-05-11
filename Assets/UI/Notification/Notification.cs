using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Notification : MonoBehaviour 
{
    [SerializeField]
    private Text text;
    public string Text
    {
        get { return text.text; }
        set { text.text = value; }
    }

    private RectTransform panelRect;

    // Use this for initialization
    public void init(float localScale, string message)
    {
        Text = message;
        panelRect = GetComponent<RectTransform>();
        panelRect.localScale *= localScale;
    }
}
