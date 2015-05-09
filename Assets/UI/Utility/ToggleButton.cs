using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleButton : MonoBehaviour 
{
	[SerializeField]
	private Color pressedColor;
	private Color notPressedColor;

	private Button button;
	private ColorBlock colorBLock;

	// Use this for initialization
	void Start () {
		button = GetComponent<Button> ();
		if (button == null)
			Debug.LogError ("[TOGGLEBUTTON]No button object component available.");

		notPressedColor = button.colors.normalColor;
		colorBLock = button.colors;
	}

	public void setPresed(bool b)
	{
		colorBLock.normalColor = ( b ? pressedColor : notPressedColor);
		button.colors = colorBLock;
	}
}
